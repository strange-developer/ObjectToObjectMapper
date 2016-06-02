using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace O2OMapper
{
  public class ObjectMapper
  {
    /// <summary>
    /// Directly maps properties from type TIn to the properties on TOut. Throws exception if property in TIn is not found in TOut
    /// </summary>
    /// <typeparam name="TIn">The type that properties will be mapped from</typeparam>
    /// <typeparam name="TOut">The type that properties will be mapped to</typeparam>
    /// <param name="srcObj">The source object that holds values to be mapped from</param>
    /// <param name="destObj">The destination object that will be mapped to</param>
    /// <returns>Returns the destObj parameter with loaded property values from srcObj</returns>
    public static TOut DirectMap<TIn, TOut>(TIn srcObj)
    {
      PropertyInfo[] props = typeof(TIn).GetProperties();
      IEnumerable<string> destPropNames = typeof(TOut).GetProperties().Select(prop => prop.Name);
      TOut destObj = Activator.CreateInstance<TOut>();
      List<string> unmatchedPropList = new List<string>();
      bool containsUnmatchedProps = false;

      foreach (PropertyInfo prop in props)
      {
        //build a list of missing properties
        if (!destPropNames.Contains(prop.Name))
        {
          unmatchedPropList.Add($"The source type {typeof(TIn).Name} does not have a matching property in destination type {typeof(TOut).Name} for property: {prop.Name}");
          containsUnmatchedProps = true;
        }

        //stop loading the destination object if there are any unmatched properties
        if (!containsUnmatchedProps)
        {
          object propVal = prop.GetValue(srcObj);
          PropertyInfo destProp = typeof(TOut).GetProperty(prop.Name);
          destProp.SetValue(destObj, propVal);
        }
      }

      if(containsUnmatchedProps)
      {
        throw new ArgumentNullException(nameof(srcObj), string.Join("\n", unmatchedPropList));
      }

      return destObj;
    }

    public static TOut DirectMapIgnoreNonExistentProps<TIn, TOut>(TIn srcObj)
    {
      PropertyInfo[] props = typeof(TIn).GetProperties();
      IEnumerable<string> destPropNames = typeof(TOut).GetProperties().Select(prop => prop.Name);
      TOut destObj = Activator.CreateInstance<TOut>();

      foreach (PropertyInfo prop in props)
      {
        if (destPropNames.Contains(prop.Name))
        {
          object propVal = prop.GetValue(srcObj);
          PropertyInfo destProp = typeof(TOut).GetProperty(prop.Name);
          destProp.SetValue(destObj, propVal);
        }
      }
      return destObj;
    }

    /// <summary>
    /// Directly maps properties from type TIn to the properties on TOut. Ignores property names specified in propsToOmit
    /// Throws exception if property in TIn is not found in TOut.
    /// </summary>
    /// <typeparam name="TIn">The type that properties will be mapped from</typeparam>
    /// <typeparam name="TOut">The type that properties will be mapped to</typeparam>
    /// <param name="srcObj">The source object that holds values to be mapped from</param>
    /// <param name="destObj">The destination object that will be mapped to</param>
    /// <param name="propsToOmit">List of property names to ignore</param>
    /// <returns>Returns the destObj parameter with loaded property values from srcObj</returns>
    public static TOut DirectMapWithOmits<TIn, TOut>(TIn srcObj, IEnumerable<string> propsToOmit)
    {
      PropertyInfo[] props = typeof(TIn).GetProperties();
      IEnumerable<string> destPropNames = typeof(TOut).GetProperties().Select(prop => prop.Name);
      TOut destObj = Activator.CreateInstance<TOut>();
      List<string> unmatchedPropList = new List<string>();
      bool containsUnmatchedProps = false;

      foreach (PropertyInfo prop in props)
      {
        if (!propsToOmit.Contains(prop.Name))
        {
          //build a list of missing properties
          if (!destPropNames.Contains(prop.Name))
          {
            unmatchedPropList.Add($"The source type {typeof(TIn).Name} does not have a matching property in destination type {typeof(TOut).Name} for property: {prop.Name}");
            containsUnmatchedProps = true;
          }

          //stop loading the destination object if there are any unmatched properties
          if (!containsUnmatchedProps)
          {
            object propVal = prop.GetValue(srcObj);
            PropertyInfo destProp = destObj.GetType().GetProperty(prop.Name);
            destProp.SetValue(destObj, propVal);
          }
        }
      }

      if (containsUnmatchedProps)
      {
        throw new ArgumentNullException(nameof(srcObj), string.Join("\n", unmatchedPropList));
      }

      return destObj;
    }

    public static TOut DirectMapWithOmitsIgnoreNonExistentProps<TIn, TOut>(TIn srcObj, IEnumerable<string> propsToOmit)
    {
      PropertyInfo[] props = typeof(TIn).GetProperties();
      IEnumerable<string> destPropNames = typeof(TOut).GetProperties().Select(prop => prop.Name);
      TOut destObj = Activator.CreateInstance<TOut>();

      foreach (PropertyInfo prop in props)
      {
        if (destPropNames.Contains(prop.Name))
        {
          if (!propsToOmit.Contains(prop.Name))
          {
            object propVal = prop.GetValue(srcObj);
            PropertyInfo destProp = destObj.GetType().GetProperty(prop.Name);
            destProp.SetValue(destObj, propVal);
          }
        }
      }
      return destObj;
    }
    
  }
}

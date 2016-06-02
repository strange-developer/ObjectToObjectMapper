using O2OMapper;
using ObjectToObjectMapper_Example;
using ObjectToObjectMapper_Example.Database;
using System;

namespace ObjectToObjectMapper.Mappings
{
  public class ProducerMappings
  {
    public static Func<Producer, ProducerDTO> ProducerToProducerDTO_WithDefault => ProducerToProducerDTOMapping_WithDefault;

    private static ProducerDTO ProducerToProducerDTOMapping_WithDefault(Producer producer)
    {
      return ObjectMapper.DirectMapWithOmitsIgnoreNonExistentProps<Producer, ProducerDTO>(producer, new string[] { "ProducerCode" });
    }

    public static Func<Producer, ProducerDTO> ProducerToProducerDTO_NoDefault => ProducerToProducerDTOMapping_NoDefault;

    private static ProducerDTO ProducerToProducerDTOMapping_NoDefault(Producer producer)
    {
      return ObjectMapper.DirectMapIgnoreNonExistentProps<Producer, ProducerDTO>(producer);
    }
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Battlehub.Storage
{
    public class ED_SerializerBase<TID,TFID> : ISurrogatesSerializer<TID>,ISerializer where TID: IEquatable<TID> where TFID :IEquatable<TFID>
    {
        private static ITypeMap m_typeMap;

        private static readonly Dictionary<int, Func<ISurrogate<TID>>> m_typeIndexToSurrogateCtor = new Dictionary<int, Func<ISurrogate<TID>>>();
        public ISurrogate<TID> CreateSurrogate(Type type)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Enqueue(object obj, ISerializationContext<TID> context)
        {
            Type type = obj.GetType();
            if (!m_typeMap.TryGetID(type, out int typeIndex))
            {
                return new ValueTask<bool>(false);
            }

            if (!m_typeIndexToSurrogateCtor.TryGetValue(typeIndex, out var surrogateCtor))
            {
                return new ValueTask<bool>(false);
            }
            ISurrogate<TID> surrogate = surrogateCtor.Invoke();
            surrogate.Serialize(obj, context);
            // m_serializationQueue.Enqueue((surrogate, typeIndex));
            return new ValueTask<bool>(true);
        }

        public Task SerializeToStream(Stream stream)
        {
            throw new NotImplementedException();
        }

        public bool CopyToDeserializationQueue()
        {
            throw new NotImplementedException();
        }

        public Task DeserializeFromStream(Stream stream)
        {
            throw new NotImplementedException();
        }

        public ValueTask<object> Dequeue(ISerializationContext<TID> context)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Serialize<T>(Stream stream, T obj)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Pack<T>> Deserialize<T>(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}

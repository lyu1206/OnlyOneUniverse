using ProtoBuf;
using System;
using System.Threading.Tasks;

namespace Battlehub.Storage.Surrogates.UnityEngine
{
    [ProtoContract]
    [Surrogate(typeof(global::UnityEngine.MeshFilter), _PROPERTY_INDEX, _TYPE_INDEX)]
    public class MeshFilterSurrogate<TID> : ISurrogate<TID> where TID : IEquatable<TID>
    {   
        const int _PROPERTY_INDEX = 5;
        const int _TYPE_INDEX = 107;

        //_PLACEHOLDER_FOR_EXTENSIONS_DO_NOT_DELETE_OR_CHANGE_THIS_LINE_PLEASE

        [ProtoMember(2)]
        public TID id { get; set; }

        [ProtoMember(3)]
        public TID gameObjectId { get; set; }

        [ProtoMember(4)]
        public TID sharedMesh { get; set; }

        //[ProtoMember(5)]
        public TID mesh { get; set; }

        //_PLACEHOLDER_FOR_NEW_PROPERTIES_DO_NOT_DELETE_OR_CHANGE_THIS_LINE_PLEASE

        public ValueTask Serialize(object obj, ISerializationContext<TID> ctx)
        {
            var idmap = ctx.IDMap;

            var o = (global::UnityEngine.MeshFilter)obj;
            id = idmap.GetOrCreateID(o);
            gameObjectId = idmap.GetOrCreateID(o.gameObject);
            sharedMesh = idmap.GetOrCreateID(o.sharedMesh);
            //mesh = idmap.GetOrCreateID(o.mesh);
            //_PLACEHOLDER_FOR_SERIALIZE_METHOD_BODY_DO_NOT_DELETE_OR_CHANGE_THIS_LINE_PLEASE

            return default;
        }

        public ValueTask<object> Deserialize(ISerializationContext<TID> ctx)
        {
            var idmap = ctx.IDMap;

            var o = idmap.GetComponent<global::UnityEngine.MeshFilter, TID>(id, gameObjectId);
            o.sharedMesh = idmap.GetObject<global::UnityEngine.Mesh>(sharedMesh);
            //o.mesh = idmap.GetObject<global::UnityEngine.Mesh>(mesh);
            //_PLACEHOLDER_FOR_DESERIALIZE_METHOD_BODY_DO_NOT_DELETE_OR_CHANGE_THIS_LINE_PLEASE

            return new ValueTask<object>(o);
        }
    }
}

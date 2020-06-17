using ArtIsPain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers
{
    public interface IRemoveChildEntities<TParentEntity, TChildEntity> where TParentEntity : IEntity
                                                                       where TChildEntity : IAuthorized
    {
    }
}

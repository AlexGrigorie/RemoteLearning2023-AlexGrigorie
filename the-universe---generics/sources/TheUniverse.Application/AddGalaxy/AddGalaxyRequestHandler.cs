using System;
using RemoteLearning.TheUniverse.Domain;
using RemoteLearning.TheUniverse.Infrastructure;

namespace RemoteLearning.TheUniverse.Application.AddGalaxy
{
    public class AddGalaxyRequestHandler : IRequestHandler<bool, AddGalaxyRequest>
    {
        public bool Execute(AddGalaxyRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string galaxyName = request.GalaxyDetailsProvider.GetGalaxyName();
            return Universe.Instance.AddGalaxy(galaxyName);
        }
    }
}
using System;
using RemoteLearning.TheUniverse.Domain;
using RemoteLearning.TheUniverse.Infrastructure;

namespace RemoteLearning.TheUniverse.Application.AddStar
{
    public class AddStarRequestHandler : IRequestHandler<bool, AddStarRequest>
    {
        public bool Execute(AddStarRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string starName = request.StarDetailsProvider.GetStarName();
            string galaxyName = request.StarDetailsProvider.GetGalaxyName();

            return Universe.Instance.AddStar(starName, galaxyName);
        }
    }
}
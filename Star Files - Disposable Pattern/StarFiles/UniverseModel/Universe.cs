using System;
using System.Collections.Generic;

namespace iQuest.StarFiles.UniverseModel
{
    internal sealed class Universe : IDisposable
    {
        private bool isDisposed = false;
        private readonly List<SimpleStar> stars = new List<SimpleStar>();

        public string CreateStarFromTemplate(string name)
        {
            SimpleStar? star = null;
            try
            {
                star = new SimpleStar(name);
                stars.Add(star);
                return star.FileName;
            }
            finally
            {
                star?.Dispose();
            }
        }

        public Tuple<string, string> CreateBinaryStar(string name)
        {
            BinaryStar star = null;
            try
            {
                star = new BinaryStar(name);
                stars.Add(star);
                return new Tuple<string, string>(star.FileName, star.AdditionalFilename);
            }
            finally
            {
                star?.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    foreach (var star in stars)
                    {
                        star.Dispose();
                    }
                }
                isDisposed = true;
            }
        }
    }
}
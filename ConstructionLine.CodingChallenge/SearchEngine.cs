using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
        }

        public List<Shirt> ShirtsResult(SearchOptions options)
        {
            List<Shirt> shirts = new List<Shirt>();

            foreach (Shirt shirt in _shirts ?? new List<Shirt>())
            {
                if((options.Sizes.Count() == 0 || options.Sizes.Contains(shirt.Size))
                    && (options.Colors.Count() == 0 || options.Colors.Contains(shirt.Color)))
                {
                    shirts.Add(shirt);
                }
            }

            return shirts;
        }

        public List<SizeCount> SizeCountResult(List<Shirt> shirts)
        {
            List<SizeCount> sizeCount = new List<SizeCount>();

            foreach(Size size in Size.All)
            {
                sizeCount.Add(new SizeCount() { Size = size, Count = shirts.Count(x => x.Size == size) });
            }

            return sizeCount;
        }

        public List<ColorCount> ColorCountResult(List<Shirt> shirts)
        {
            List<ColorCount> colorCount = new List<ColorCount>();

            foreach (Color color in Color.All)
            {
                colorCount.Add(new ColorCount() { Color = color, Count = shirts.Count(x => x.Color == color) });
            }

            return colorCount;
        }

        public SearchResults Search(SearchOptions options)
        {
            // TODO: search logic goes here.
            List<Shirt> results = ShirtsResult(options);

            return new SearchResults
            {
                Shirts = results,
                SizeCounts = SizeCountResult(results),
                ColorCounts = ColorCountResult(results)
            };
        }
    }
}
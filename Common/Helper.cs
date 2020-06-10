using System.Linq;
using Coypu;

namespace DotnetQaFront.Common
{
    public class Helper
    {
        public static SnapshotElementScope getElementByIndex(BrowserSession browser, string selector, int index)
        {
            var allToClick = browser.FindAllCss(selector);

            return allToClick.ToList()[index];
        }
    }
}
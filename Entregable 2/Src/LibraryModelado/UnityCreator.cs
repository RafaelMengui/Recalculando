using System;
using Proyecto.Common;
namespace Proyecto.LibraryModelado
{
    public class UnityCreator
    {
        public void CreatorU(IMainViewAdapter adapter)
        {
            Creator c = Singleton<Creator>.Instance;

            foreach (Space level in c.World.SpaceList)
            {
                level.CreateUnityLevel(adapter);
                foreach (Items item in level.ItemList)
                {
                    item.CreateUnityItem(adapter);
                }
            }
        }
    }
}
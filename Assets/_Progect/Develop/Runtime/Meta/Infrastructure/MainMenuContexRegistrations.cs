using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContexRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Процесс регистрации сервисов на сцене меню");
            //container.RegisterAsSingle(CreateWalletPresenor).NonLazy();
        }

        //private static WalletPresentor CreateWalletPresenor(DIContainer c)
        //{
        //    IconTextListView walletView = Object.FindObjectOfType<IconTextListView>();


        //    WalletPresentor walletPresentor = c.Resolve<ProjectPresentorFactory>().CreateWalletPresentor(walletView);


        //    return walletPresentor;
        //}
    }
}

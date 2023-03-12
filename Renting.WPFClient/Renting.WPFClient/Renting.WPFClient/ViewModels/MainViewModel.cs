using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

using Renting.WPFClient.ViewModels.Base;

namespace Renting.WPFClient.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        private Random rnd = new Random();


        //private HTable<Ship> _MyCollection = new HTable<Ship>();
        //public HTable<Ship> MyCollection
        //{
        //    get => _MyCollection;
        //    set => Set(ref _MyCollection, value);
        //}


        //private string _CollectionTextView = "Коллекция пустая";
        //public string CollectionTextView
        //{
        //    get
        //    {
        //        return _CollectionTextView;
        //    }
        //    set
        //    {
        //        Set(ref _CollectionTextView, value);
        //    }
        //}



        //public ICommand AddShip { get; }
        //private bool CanAddShipExecute(object p)
        //{
        //    return true;
        //}
        //private void OnAddShipExecuted(object p)
        //{
        //    int speed = 0;
        //    if (int.TryParse(ShipSpeedToAdd, out speed))
        //    {
        //        AddMessage = "Успешно";
        //        MyCollection.Add(new Ship(ShipNameToAdd, speed));
        //        CollectionTextView = MyCollection.TextView;
        //    }
        //    else
        //    {
        //        AddMessage = "Ошибка";
        //    }
        //}






        public MainViewModel()
        {
            //MyCollection = new HTable<Ship>(100);
            //AddShip = new LambdaCommand(OnAddShipExecuted, CanAddShipExecute);
            //RemoveIndex = new LambdaCommand(OnRemoveIndexExecuted, CanRemoveIndexExecute);
            //ChangeItem = new LambdaCommand(OnChangeItemExecuted, CanChangeItemExecute);

            //LoadToBinary = new LambdaCommand(OnLoadToBinaryExecuted, CanLoadToBinaryExecute);
            //LoadToJSON = new LambdaCommand(OnLoadToJSONExecuted, CanLoadToJSONExecute);
            //LoadToXML = new LambdaCommand(OnLoadToXMLExecuted, CanLoadToXMLExecute);
            //LoadFromBinary = new LambdaCommand(OnLoadFromBinaryExecuted, CanLoadFromBinaryExecute);
            //LoadFromJSON = new LambdaCommand(OnLoadFromJSONExecuted, CanLoadFromJSONExecute);
            //LoadFromXML = new LambdaCommand(OnLoadFromXMLExecuted, CanLoadFromXMLExecute);
        }
    }
}

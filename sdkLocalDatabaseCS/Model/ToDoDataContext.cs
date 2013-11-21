/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LocalDatabaseSample.Model
{


    #region CLASSE TDODATACONTEXT
    public class ToDoDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public ToDoDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<ToDoItem> Items;

        // Specify a table for the categories.
        public Table<ToDoCategory> Categories;
    }

    #endregion CLASSE TODODATACONTEXT

    #region CLASSE PASTI
    [Table]
    public class ToDoMeals : INotifyPropertyChanged, INotifyPropertyChanging
    {
        //VAR: id
        private int _toDoMealId;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ToDoMealId
        {
            get { return _toDoMealId; }

            set
            {
                if (this._toDoMealId != value)
                {
                    NotifyPropertyChanging("ToDoMealId");
                    this._toDoMealId = value;
                    NotifyPropertyChanged("ToDoMealId");
                }
            }
        
        }

        //VAR: (performance)
        [Column(IsVersion = true)]
        private Binary _version;

        //VAR: data
        private string _date;
        [Column]
        public string Date
        {
            get { return _date; }

            set { this._date = value; }
        }


        //VAR: Quantita del prodotto del pasto (perchè l'item ha una quantità?????)
        private int _quantity;
        [Column]
        public int Quantity
        {

            get { return this._quantity; }

            set { this._quantity = value; }

        }


        //VAR:Carboidrati totali del pasto
        private double _carboidrati;
        [Column]
        public double Carboidrati
        {

            get
            {

                return this._carboidrati;
            }

            set
            {
                this._carboidrati = value;
            }

        }

        //VAR: grassi totali del pasto
        private double _grassi;
        [Column]
        public double Grassi
        {

            get
            {

                return this._grassi;
            }

            set
            {
                this._grassi = value;
            }

        }


        //VAR: proteine totali del pasto
        private double _proteine;
        [Column]
        public double Proteine
        {

            get
            {

                return this._proteine;
            }

            set
            {
                this._proteine = value;
            }
        }


        //VAR: calorie totali del pasto
        private double _calorie;
        [Column]
        public double Calorie
        {

            get
            {

                return this._calorie;
            }

            set
            {
                this._calorie = value;
            }

        }

        //VAR: set di items prodotti per giornata
        private EntitySet<ToDoItem> _todos;
        [Association(Storage = "_todos", OtherKey = "_toDoItemId", ThisKey = "ToDoMealId")]
        public EntitySet<ToDoItem> ToDos
        {
            get { return this._todos; }
            set { this._todos.Assign(value); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion

    }
    #endregion CLASSE PASTI

    #region CLASSE PRODOTTI

    [Table]
    public class ToDoItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _toDoItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ToDoItemId
        {
            get { return _toDoItemId; }
            set
            {
                if (_toDoItemId != value)
                {
                    NotifyPropertyChanging("ToDoItemId");
                    _toDoItemId = value;
                    NotifyPropertyChanged("ToDoItemId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _itemName;

        [Column]
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    NotifyPropertyChanging("ItemName");
                    _itemName = value;
                    NotifyPropertyChanged("ItemName");
                }
            }
        }

        // Define completion value: private field, public property, and database column.
        private bool _isComplete;

        [Column]
        public bool IsComplete
        {
            get { return _isComplete; }
            set
            {
                if (_isComplete != value)
                {
                    NotifyPropertyChanging("IsComplete");
                    _isComplete = value;
                    NotifyPropertyChanged("IsComplete");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        
        // Quantita del prodotto
        [Column]
        private int _quantity;
        public int Quantity {

            get {

                return this._quantity;
            }

            set { 
                this._quantity = value; 
            }

        }


        // Carboidrati del prodotto
        [Column]
        private double _carboidrati;
        public double Carboidrati
        {

            get
            {

                return this._carboidrati;
            }

            set
            {
                this._carboidrati = value;
            }

        }

        // Grassi del prodotto
        [Column]
        private double _grassi;
        public double Grassi
        {

            get
            {

                return this._grassi;
            }

            set
            {
                this._grassi = value;
            }

        }


        // Proteine del prodotto
        [Column]
        private double _proteine;
        public double Proteine
        {

            get
            {

                return this._proteine;
            }

            set
            {
                this._proteine = value;
            }
        }


        // Calorie del prodotto
        [Column]
        private double _calorie;
        public double Calorie
        {

            get
            {

                return this._calorie;
            }

            set
            {
                this._calorie = value;
            }

        }



        // Porzione media del prodotto
        [Column]
        private double _medium;
        public double Medium
        {

            get
            {

                return this._medium;
            }

            set
            {
                this._medium = value;
            }

        }


        // Porzione small del prodotto
        [Column]
        private double _small;
        public double Small
        {

            get
            {

                return this._small;
            }

            set
            {
                this._small = value;
            }

        }


        // Porzione big del prodotto
        [Column]
        private double _big;
        public double Big
        {

            get
            {

                return this._big;
            }

            set
            {
                this._big= value;
            }

        }

        // Internal column for the associated ToDoCategory ID value
        [Column]
        internal int _categoryId;

        // Entity reference, to identify the ToDoCategory "storage" table
        private EntityRef<ToDoCategory> _category;

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_category", ThisKey = "_categoryId", OtherKey = "Id", IsForeignKey = true)]
        public ToDoCategory Category
        {
            get { return _category.Entity; }
            set
            {
                NotifyPropertyChanging("Category");
                _category.Entity = value;

                if (value != null)
                {
                    _categoryId = value.Id;
                }

                NotifyPropertyChanging("Category");
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

    #endregion CLASSE PASTI

    #region CLASSE CATEGORIE

    [Table]
    public class ToDoCategory : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _id;

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get { return _id; }
            set
            {
                NotifyPropertyChanging("Id");
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        // Define category name: private field, public property, and database column.
        private string _name;

        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                NotifyPropertyChanging("Name");
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        // Define the entity set for the collection side of the relationship.
        private EntitySet<ToDoItem> _todos;

        [Association(Storage = "_todos", OtherKey = "_categoryId", ThisKey = "Id")]
        public EntitySet<ToDoItem> ToDos
        {
            get { return this._todos; }
            set { this._todos.Assign(value); }
        }


        // Assign handlers for the add and remove operations, respectively.
        public ToDoCategory()
        {
            _todos = new EntitySet<ToDoItem>(
                new Action<ToDoItem>(this.attach_ToDo),
                new Action<ToDoItem>(this.detach_ToDo)
                );
        }

        // Called during an add operation
        private void attach_ToDo(ToDoItem toDo)
        {
            NotifyPropertyChanging("ToDoItem");
            toDo.Category = this;
        }

        // Called during a remove operation
        private void detach_ToDo(ToDoItem toDo)
        {
            NotifyPropertyChanging("ToDoItem");
            toDo.Category = null;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

    #endregion CLASSE CATEGORIE

}

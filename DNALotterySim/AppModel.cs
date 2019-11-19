using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;

namespace DNALotterySim
{
    public class Item : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }
        public Item(string name, int value, string color)
        {
            Name = name;
            Value = value;
            Color = color;
        }

        #region Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class Prize : INotifyPropertyChanged
    {
        public Item Item { get; set; }
        public int Count { get; set; }
        public int Value { get { return Item.Value * Count; } }
        public double Rate { get; set; }
        public double Expect { get { return Convert.ToDouble(Value) * Rate; } }
        public double Val_Start { get; set; }
        public double Val_End { get; set; }
        public Prize(List<Item> baseItems, List<Prize> targetPrizes, string name, int count, double rate)
        {
            Item = baseItems.Where(e => e.Name == name).First();
            Count = count;
            Rate = rate;

            Val_Start = targetPrizes.Sum(e => e.Rate);
            Val_End = Val_Start + rate;
        }


        #region Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class AppModel : INotifyPropertyChanged
    {


        public List<Item> Items { get; set; }

        #region CJWJ
        public List<Prize> Prizes_CJWJ { get; set; }

        private ObservableCollection<Prize> _CJWJ_Prizes_Temp;
        public ObservableCollection<Prize> CJWJ_Prizes_Temp
        {
            get { return _CJWJ_Prizes_Temp; }
            set
            {
                _CJWJ_Prizes_Temp = value;
                OnPropertyChanged("CJWJ_Prizes_Temp");
                OnPropertyChanged("CJWJ_Point_Temp");
                OnPropertyChanged("CJWJ_Sum_Temp");
                OnPropertyChanged("CJWJ_Ratio_Temp");
            }
        }

        public int CJWJ_Point { get; set; }
        public int CJWJ_Point_Temp
        {
            get { return CJWJ_Prizes_Temp.Count * CJWJ_Point; }
        }
        public double CJWJ_Sum
        {
            get
            {
                return Prizes_CJWJ.Select(e => e.Expect).Sum();
            }
        }
        public double CJWJ_Sum_Temp
        {
            get
            {
                return CJWJ_Prizes_Temp.Select(e => e.Value).Sum();
            }
            set
            {
                OnPropertyChanged("CJWJ_Sum_Temp");
            }
        }
        public double CJWJ_Ratio
        {
            get
            {
                return CJWJ_Sum / Convert.ToDouble(CJWJ_Point);
            }
        }
        public double CJWJ_Ratio_Temp
        {
            get
            {
                return CJWJ_Sum_Temp / Convert.ToDouble(CJWJ_Point_Temp);
            }
        }
        #endregion

        #region XYBZ2
        public List<Prize> Prizes_XYBZ2 { get; set; }

        private ObservableCollection<Prize> _XYBZ2_Prizes_Temp;
        public ObservableCollection<Prize> XYBZ2_Prizes_Temp
        {
            get { return _XYBZ2_Prizes_Temp; }
            set
            {
                _XYBZ2_Prizes_Temp = value;
                OnPropertyChanged("XYBZ2_Prizes_Temp");
                OnPropertyChanged("XYBZ2_Point_Temp");
                OnPropertyChanged("XYBZ2_Sum_Temp");
                OnPropertyChanged("XYBZ2_Ratio_Temp");
            }
        }

        public int XYBZ2_Point { get; set; }
        public int XYBZ2_Point_Temp
        {
            get { return XYBZ2_Prizes_Temp.Count * XYBZ2_Point; }
        }
        public double XYBZ2_Sum
        {
            get
            {
                return Prizes_XYBZ2.Select(e => e.Expect).Sum();
            }
        }
        public double XYBZ2_Sum_Temp
        {
            get
            {
                return XYBZ2_Prizes_Temp.Select(e => e.Value).Sum();
            }
            set
            {
                OnPropertyChanged("XYBZ2_Sum_Temp");
            }
        }
        public double XYBZ2_Ratio
        {
            get
            {
                return XYBZ2_Sum / Convert.ToDouble(XYBZ2_Point);
            }
        }
        public double XYBZ2_Ratio_Temp
        {
            get
            {
                return XYBZ2_Sum_Temp / Convert.ToDouble(XYBZ2_Point_Temp);
            }
        }
        #endregion

        #region Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public AppModel()
        {
            #region Items
            Items = new List<Item>();
            Items.Add(new Item("稳态碎片", 10, "Black"));
            Items.Add(new Item("稳态晶块", 99, "Black"));
            Items.Add(new Item("永燃之火", 40, "Black"));
            Items.Add(new Item("冥界之焰", 198, "Black"));
            Items.Add(new Item("赋能礼包1000", 1000, "Orange"));

            Items.Add(new Item("10级圣核兑换券", 1783, "Orange"));

            Items.Add(new Item("蓝宝石饮剂", 10, "Black"));
            Items.Add(new Item("紫晶石饮剂", 100, "Black"));

            Items.Add(new Item("缤纷颜料卡", 16, "Black"));
            Items.Add(new Item("缤纷颜料罐", 96, "Black"));

            Items.Add(new Item("宠物辅助技能I", 998, "Orange"));
            Items.Add(new Item("宠物辅助技能II", 1297, "Orange"));
            Items.Add(new Item("宠物辅助技能III", 1497, "Orange"));
            Items.Add(new Item("宠物芯片I", 497, "Purple"));
            Items.Add(new Item("宠物芯片II", 1485, "Orange"));

            Items.Add(new Item("进化石", 198, "Black"));
            Items.Add(new Item("源光进化石", 998, "Orange"));
            Items.Add(new Item("高级座驾改装图", 790, "Purple"));

            Items.Add(new Item("时装头发·蔷薇十字", 4980, "Gold"));
            Items.Add(new Item("时装衣服·蔷薇十字", 9989, "Gold"));
            Items.Add(new Item("时装头发·特调搜查部", 4980, "Gold"));
            Items.Add(new Item("时装衣服·特调搜查部", 9989, "Gold"));

            Items.Add(new Item("手办·凯撒-兜风", 2998, "Gold"));

            Items.Add(new Item("座驾·咩咩快跑", 24888, "Gold"));
            Items.Add(new Item("座驾·极域流星", 24888, "Gold"));
            #endregion

            #region CJWJ

            CJWJ_Point = 50;

            Prizes_CJWJ = new List<Prize>();
            CJWJ_Prizes_Temp = new ObservableCollection<Prize>();

            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "稳态碎片", 5, 0.18));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "稳态晶块", 2, 0.015));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "永燃之火", 2, 0.1768));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "冥界之焰", 1, 0.05));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "赋能礼包1000", 1, 0.012));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "10级圣核兑换券", 1, 0.012));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "蓝宝石饮剂", 5, 0.18));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "紫晶石饮剂", 1, 0.16));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "缤纷颜料卡", 5, 0.09));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "缤纷颜料罐", 1, 0.08));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "宠物辅助技能I", 1, 0.0008));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "宠物辅助技能II", 1, 0.0006));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "宠物辅助技能III", 1, 0.0003));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "宠物芯片I", 1, 0.0048));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "宠物芯片II", 1, 0.0015));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "进化石", 1, 0.03));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "源光进化石", 1, 0.0018));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "高级座驾改装图", 1, 0.0025));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "时装头发·蔷薇十字", 1, 0.0005));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "时装衣服·蔷薇十字", 1, 0.0003));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "时装头发·特调搜查部", 1, 0.0007));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "时装衣服·特调搜查部", 1, 0.0004));
            Prizes_CJWJ.Add(new Prize(Items, Prizes_CJWJ, "座驾·咩咩快跑", 1, 0.0002));
            #endregion

            #region XYBZ2

            XYBZ2_Point = 50;

            Prizes_XYBZ2 = new List<Prize>();
            XYBZ2_Prizes_Temp = new ObservableCollection<Prize>();

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "稳态碎片", 5, 0.18));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "稳态晶块", 2, 0.05));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "永燃之火", 2, 0.1872));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "冥界之焰", 1, 0.05));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "赋能礼包1000", 1, 0.008));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "10级圣核兑换券", 1, 0.008));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "蓝宝石饮剂", 5, 0.15));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "紫晶石饮剂", 1, 0.16));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "缤纷颜料卡", 5, 0.09));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "缤纷颜料罐", 1, 0.08));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "宠物辅助技能I", 1, 0.0010));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "宠物辅助技能II", 1, 0.0008));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "宠物辅助技能III", 1, 0.0005));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "宠物芯片I", 1, 0.0025));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "宠物芯片II", 1, 0.0015));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "进化石", 1, 0.025));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "源光进化石", 1, 0.0018));
            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "高级座驾改装图", 1, 0.0025));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "手办·凯撒-兜风", 1, 0.001));

            Prizes_XYBZ2.Add(new Prize(Items, Prizes_XYBZ2, "座驾·极域流星", 1, 0.0002));
            #endregion
        }


        public Prize Roll(List<Prize>prizes, Random random)
        {
            double val_total = prizes.Sum(e => e.Rate);
            double test_num = random.NextDouble() * val_total;

            foreach (Prize prize in prizes)
            {
                if (test_num < prize.Val_End && test_num >= prize.Val_Start)
                {
                    return (prize);
                }
            }

            return null;
        }
    }

}

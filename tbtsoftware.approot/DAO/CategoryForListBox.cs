namespace bnb.approot.DAO
{
    using System;

    public class CategoryForListBox
    {
        #region Constructors and Destructors

        public CategoryForListBox(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public CategoryForListBox()
        {
        }

        #endregion

        #region Public Properties

        public string Description { get; set; }

        public string ID { get; set; }

        public Boolean IsDelete { get; set; }

        public Boolean IsDisplay { get; set; }

        public string Name { get; set; }

        public int OrderSort { get; set; }

        public string ParentID { get; set; }

        #endregion
    }

    public class MenuForListBox
    {
        #region Constructors and Destructors

        public MenuForListBox(int p_Id, string p_Name)
        {
            this.Id = p_Id;
            this.Name = p_Name;
        }

        public MenuForListBox()
        {
        }

        #endregion

        #region Public Properties

        public string Descript { get; set; }

        public int Id { get; set; }

        public string ImgSrc { get; set; }

        public Boolean IsDelete { get; set; }

        public Boolean IsDisplay { get; set; }

        public string Link { get; set; }

        public string Name { get; set; }

        public int OrderSort { get; set; }

        public string ParentID { get; set; }

        #endregion
    }
}
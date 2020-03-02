using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALlab
{
    public class Repository
    {
        #region details
        //public void signup(detail d)
        //{

        //}
        public bool login(detail d)
        {

            using (var db = new LabStorageEntities())
            {
                List<detail> l = db.details.ToList();
                bool status = false;
                foreach (var item in l)
                {
                    if((item.password==d.password)&&(item.username==d.username))
                    {
                        status = true;
                       
                    }
                    else
                    {
                        status = false;
                       
                    }
                   
                }
                if (status == true)
                {
                    return status;
                }
                    
                else
                {
                    status = false;
                    return status;
                }
               
            }

        }
        #endregion

        #region records
        public List<record> display()
        {
            List<record> list = new List<record>();
            //List<display_items_Result> list = new List<display_items_Result>();
            using (var db = new LabStorageEntities())
            {
                list = db.records.ToList();
                //list = db.display_items().ToList();
            }
            return list;
        }

        public bool additem(record r)
        {
            bool status = false;
            using (var db = new LabStorageEntities())
            {
                db.records.Add(r);
                db.SaveChanges();
                status = true;
                return status;
            }
        }

        public void modifyitem(int id,record r)
        {
            List<record> l = new List<record>();
            using (var db = new LabStorageEntities())
            {
                l = db.records.ToList();

                foreach (var item in l)
                {
                    if (item.id == id)
                    {
                        item.category = r.category;
                        item.itemname = r.itemname;
                        item.noofitems = r.noofitems;
                    }
                }
                db.SaveChanges();
            }

        }

        public void deleteitem(int id,record r)
        {
            using (var db = new LabStorageEntities())
            {
                db.records.Remove(db.records.Where(s=>s.id==id).FirstOrDefault());
                db.SaveChanges();
            }


        }

        public List<searchitem_Result> searchitem(string s)
        {
            List<searchitem_Result> l = new List<searchitem_Result>();
            using (var db = new LabStorageEntities())
            {
                l = db.searchitem(s).ToList();
               
            }
            return l;

        }

        #endregion

    }
}

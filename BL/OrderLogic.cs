using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;

namespace BL
{


    class OrderLogic : BaseLogic
    {
        ShachlavDB2 db = new ShachlavDB2();

        public OrderDto getOrderById(int id)
        {
            try
            {
                Order o = db.Orders.FirstOrDefault(or => or.Id == id);
                if (o != null)
                {
                    return DaltoDto(o);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderDto> getAllOrders()
        {
            List<OrderDto> AllOrders = new List<OrderDto>();
            foreach (Order o in db.Orders)
            {
                AllOrders.Add(DaltoDto(o));
            }
            return AllOrders;
        }

        public List<OrderDto> getOrdersbyCustId(int id)
        {
            try
            {

                List<OrderDto> custOrders = new List<OrderDto>();
                foreach (Order o in db.Orders)
                {
                    if (o.CustomerId == id)
                        custOrders.Add(DaltoDto(o));
                }
                return custOrders;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        // למנהל ללקוח לעשות לפי ID?
        public List<OrderDto> getOrdersbyOrderDate(DateTime d)
        {
            try {
                List<OrderDto> dateOrders = new List<OrderDto>();
                foreach(Order o in db.Orders)
                {
                    if (o.OrderDate == d)
                        dateOrders.Add(DaltoDto(o));

                }
                return dateOrders;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        //למנהל ללקוח לעשות לפי ID? או לעשות פרמטר ID אופציונלי
        public List<OrderDto> getOpenOrders()
        {
            try {
                List<OrderDto> openOrders = new List<OrderDto>();
                foreach(Order o in db.Orders)
                {
                    if (o.IsDone == false)
                        openOrders.Add(DaltoDto(o));
                }
                return openOrders;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // לשנות את הDB ולהוסיף עיר?
        //לנהג מנהל ולקוח
        public List<OrderDto> getOrdersbyAddress(string address)
        {
            try
            {

                List<OrderDto> cityOrders = new List<OrderDto>();
                foreach (Order o in db.Orders)
                {
                    if (o.SiteAdress.Contains(address))
                        cityOrders.Add(DaltoDto(o));
                }
                return cityOrders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsExists(Order o)
        {
            if (db.Orders.First(or => or.Id == o.Id) != null)
                return true;
            else return false;
        }

        public OrderDto DaltoDto(Order o)
        {
            return new OrderDto()
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                OrderTime = o.OrderTime,
                Element = o.Element,
                SiteAdress = o.SiteAdress,
                ConcreteCheck = o.ConcreteCheck,
                PumpNeeded = o.PumpNeeded,
                PumpType = o.PumpType,
                StartTime = o.StartTime,
                EndTime = o.EndTime,
                IsIssue = o.IsIssue,
                Status = o.Status

            };
        }

        public Order DtoToDal(OrderDto o)
        {
            return new Order()
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                OrderTime = o.OrderTime,
                Element = o.Element,
                SiteAdress = o.SiteAdress,
                ConcreteCheck = o.ConcreteCheck,
                PumpNeeded = o.PumpNeeded,
                PumpType = o.PumpType,
                StartTime = o.StartTime,
                EndTime = o.EndTime,
                IsIssue = o.IsIssue,
                Status = o.Status
            };
        }
    }


}

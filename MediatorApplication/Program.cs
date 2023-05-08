using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator med = new MediatorImpl();
            User Patrick = new UserImpl(med, "Patrick");
            User Nova = new UserImpl(med, "Nova");
            User Devin = new UserImpl(med, "Devin");
            User Angel = new UserImpl(med, "Angel");

            med.registerUser(Patrick);
            med.registerUser(Nova);
            med.registerUser(Devin);
            med.registerUser(Angel);

            Patrick.send("Hi, everyone!");

            
            Console.Read();
        }


    }
    public abstract class User
    {
        public Mediator _mediator;

        public string _name;

        public User()
        {

        }
        
        

        public User(Mediator med, string name)
        {
            _mediator = med;
            _name = name;
        }

        public abstract void send(string message);
        public abstract void receive(string message);
    }

    public class UserImpl : User
    {
        
         public UserImpl(Mediator med, string name)
        {
            _mediator = med;
            _name = name;
        }

        public override void send(string message)
        {
            Console.WriteLine(_name + " : Sending message: " +message);
            _mediator.sendMessage(message, this);
        }
        public override void receive(string message)
        {
            Console.WriteLine(_name + ": Received message: " +message);
        }
    }

    public interface Mediator
    {
         void sendMessage(string message, User user);
         void registerUser(User user);

    }

    public class MediatorImpl: Mediator
    {
        private List<User> _users;

        public MediatorImpl()
        {
            _users = new List<User>();
        }

        public void sendMessage(string message, User user)
        {
            foreach(User u in  _users)
            {
                if(u != user)
                {
                    u.receive(message);
                }
            }

        }
        public void registerUser(User user)
        {
            _users.Add(user);
        }

    }
 }


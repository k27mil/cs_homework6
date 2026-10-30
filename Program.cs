using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_homework6
{
    public abstract class Notification
    {
        private string _recipient;
        private string _text;
        private string _status;
        private string _date;
        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string Status
        {
            get { return _status; }
            protected set { _status = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public Notification(string recipient, string text)
        {
            _recipient = recipient;
            _text = text;
            _status = "Создано";
            _date = "Сегодня";
        }

        public abstract void Send();

        public virtual void Retry()
        {
            Send();
        }

        public void MarkAsRead()
        {
            _status = "Прочитано";
        }

        public virtual void GatherStats()
        {
            Console.WriteLine($"Статус: {_status}");
        }

        public void ExportLog()
        {
            Console.WriteLine($"Лог: {_recipient} - {_status}");
        }
    }

    public class Email : Notification
    {
        private string _subject;

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public Email() : base("Нет", "Пусто")
        {
            _subject = "Нет";
        }

        public Email(string to, string sub, string txt) : base(to, txt)
        {
            _subject = sub;
        }

        public override void Send()
        {
            Console.WriteLine($"Email для {Recipient}: {Text}");
        }
    }

    public class SMS : Notification
    {
        private bool _delivered;

        public bool Delivered
        {
            get { return _delivered; }
            set { _delivered = value; }
        }

        public SMS() : base("Нет", "Пусто")
        {
            _delivered = false;
        }

        public SMS(string to, string txt) : base(to, txt)
        {
            _delivered = false;
        }

        public override void Send()
        {
            Console.WriteLine($"SMS для {Recipient}: {Text}");
        }
    }

    public class Push : Notification
    {
        private string _app;

        public string App
        {
            get { return _app; }
            set { _app = value; }
        }

        public Push() : base("Нет", "Пусто")
        {
            _app = "App";
        }

        public Push(string to, string app, string txt) : base(to, txt)
        {
            _app = app;
        }

        public override void Send()
        {
            Console.WriteLine($"Push от {App}: {Text}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задача: Уведомления");

            Email mail = new Email("student@kpfu.ru", "ООП", "Завтра лекция");
            mail.Send();
            mail.MarkAsRead();
            mail.ExportLog();

            SMS sms = new SMS("+79999999999", "Ваш код: 1234");
            sms.Send();
            sms.GatherStats();

            Push push = new Push("Device_1", "Telegram", "Новое сообщение");
            push.Send();
            push.ExportLog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба7 {
	class Date {
		public DateTime date;

		public Date() {

			do {
				Console.Write("Введите дату(дд.мм.гггг): ");
				if (DateTime.TryParse(Console.ReadLine(), out date)) {
					DateTime data = new DateTime(2009, 01, 1);
					Console.WriteLine(data.ToString("d.MM.yyyy"));
					break;
				}
				else {
					Console.WriteLine("Ошибка");
				}

			}
			while (true);
		}

		public void days() {
			DateTime now = date;
			DateTime yesterday = now.AddDays(-1);
			DateTime tomorrow = now.AddDays(1);
			int daysLeft = DateTime.DaysInMonth(now.Year, now.Month) - now.Day;
			Console.Write(" "
				+ "\nВчера: " + yesterday.ToString("dd.MM.yyyy")
				+ "\nЗавтра: " + tomorrow.ToString("dd.MM.yyyy")
				+ "\nОсталось дней до конца месяца: " + daysLeft);
		}
		public int leapYear {
			get {
				int year;
				do {
					Console.Write("Введите год:");
					if (Int32.TryParse(Console.ReadLine(), out year)) {
						break;
					}
					else {
						Console.WriteLine("Ошибка");
					}
				}
				while (true);
				return year;
			}
			set {
				leapYear = 0;
			}
		}
		public string leap {
			get {
				string yes;
				bool lea = DateTime.IsLeapYear(leapYear);
				if (lea == true) { yes = "Высокосный"; } else { yes = "Не высокосный"; }
				return yes;
			}
		}
		public void knowLeap() {
			Console.Write("" + leap);
		}

		public DateTime this[int index] {
			get {
				return date.AddDays(index);
			}
		}

		public static bool operator !(Date a) {
			return a.date.Day != DateTime.DaysInMonth(a.date.Year, a.date.Month);
		}

		public static bool operator true(Date a) {
			return a.date.Day == 1 && a.date.Month == 1;
		}

		public static bool operator false(Date a) {
			return a.date.Day != 1 || a.date.Month != 1;
		}

		public static bool operator &(Date a, Date b) {
			return a.date.Equals(b.date);
		}

		public static explicit operator String(Date day) {
			return day.date.Day + "." + day.date.Month + "." + day.date.Year;
		}

		public Date(int year, int month, int day) {
			date = new DateTime(year, month, day);
		}

		public static explicit operator Date(String str) {
			string[] str_arr = str.Split(new char[] { ' ', ',', '/', '.' }, StringSplitOptions.RemoveEmptyEntries);
			Date obj = new Date(Convert.ToInt32(str_arr[0]), Convert.ToInt32(str_arr[1]), Convert.ToInt32(str_arr[2]));
			return obj;
		}
		internal class Program {
			static void Main(string[] args) {
				Date d = new Date();
				Console.WriteLine("");
				d.days();
				Console.WriteLine("\n");
				d.knowLeap();
				Console.WriteLine("\n");

				Console.Write("Введите i-тое число относительно Установленной даты(" + d.date.ToString("dd.MM.yyyy") + "): ");

				int N;
				do {
					if (Int32.TryParse(Console.ReadLine(), out N)) {
						break;
					}
					else {
						Console.WriteLine("Ошибка");
					}

				} while (true);
				Console.Write("Будет: " + d[N].ToString("dd.MM.yyyy") + "\n");

				Console.Write("Дата не является последним днём месяца: " + !d);
				Console.WriteLine("\n");
				Date b = new Date();
				Console.Write("Сравнение полей двух объектов: {0}", d & b);
				Console.WriteLine("\n");
				Console.WriteLine("Преобразовани  DataTime в string: " + (string)d);
				Date d2 = (Date)d;
				Console.WriteLine("Преобразования класса string в тип DataTime: "+ d2.date.ToShortDateString());
				Console.WriteLine("\n");

				if (d) {
					Console.WriteLine("Начало года");
				}
				else { Console.WriteLine("Не начало года"); }

			}
		}
	}
}

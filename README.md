# 🍕 PizzaTata - Web API Management System

## 📋 תיאור הפרויקט
מערכת ניהול פיצריה מתקדמת המבוססת על Web API ב-.NET 8. המערכת מאפשרת ניהול מלא של פיצות, עובדים והזמנות עם מערכת אימות מתקדמת.

## 🚀 תכונות עיקריות

### 🍕 ניהול פיצות
- הוספת פיצות חדשות
- חיפוש פיצות לפי ID
- עדכון פרטי פיצות (גלוטן)
- מחיקת פיצות
- ניהול רשימת פיצות

### 👥 ניהול עובדים
- רישום עובדים חדשים
- מעקב אחר שעות עבודה
- ניהול פרטי עובדים

### 📦 ניהול הזמנות
- יצירת הזמנות חדשות
- ניהול פרטי לקוחות
- תמיכה בכרטיסי אשראי
- מעקב אחר תאריכי הזמנות

### 🔐 אבטחה ואימות
- JWT Authentication
- מערכת הרשאות מתקדמת (Admin, SuperWorker)
- אבטחת API endpoints
- ניהול משתמשים מאובטח

## 🛠️ טכנולוגיות

- **.NET 8** - Framework ראשי
- **ASP.NET Core Web API** - בניית ה-API
- **JWT Bearer Authentication** - מערכת אימות
- **Swagger/OpenAPI** - תיעוד API
- **Newtonsoft.Json** - עיבוד JSON
- **File-based Storage** - אחסון נתונים בקבצי JSON

## 📁 מבנה הפרויקט

```
FinishProjectWebapi/
├── pizza/                 # הפרויקט הראשי (Web API)
│   ├── Controllers/       # API Controllers
│   ├── Login/            # שירותי אימות
│   ├── Middlewares/      # Middleware components
│   └── Program.cs        # הגדרת האפליקציה
├── models/               # מודלים של הנתונים
│   ├── PizzaTata.cs      # מודל פיצה
│   ├── WorkerModels.cs   # מודל עובד
│   ├── OrderModel.cs     # מודל הזמנה
│   └── CreditCard.cs     # מודל כרטיס אשראי
├── ServiceCL/            # שירותים עסקיים
│   ├── PizzaService.cs   # שירות פיצות
│   ├── WorkerService.cs  # שירות עובדים
│   └── OrderServ.cs      # שירות הזמנות
└── FileServise/          # שירות ניהול קבצים
    └── ReadWrite.cs      # קריאה וכתיבה לקבצים
```

## 🚀 התקנה והרצה

### דרישות מקדימות
- .NET 8 SDK
- Visual Studio 2022 או VS Code

### שלבי התקנה
1. Clone את הפרויקט:
```bash
git clone [repository-url]
cd FinishProjectWebapi
```

2. פתח את הפרויקט ב-Visual Studio או VS Code

3. הרץ את הפרויקט:
```bash
cd pizza
dotnet run
```

4. פתח את הדפדפן בכתובת: `https://localhost:7000` או `http://localhost:5000`

5. גש ל-Swagger UI: `https://localhost:7000/swagger`

## 📚 API Endpoints

### פיצות (Pizza)
- `POST /PostPizza` - הוספת פיצה חדשה
- `GET /getById/{id}` - חיפוש פיצה לפי ID
- `POST /AddPizza/{name}/{isGluten}/{id}` - הוספת פיצה עם פרמטרים
- `GET /deletpizza/{id}` - מחיקת פיצה (דורש הרשאה)
- `PUT /updateGlutan/{id}` - עדכון סטטוס גלוטן (דורש הרשאה)

### עובדים (Workers)
- `GET /GetWorkers` - קבלת רשימת עובדים
- `POST /AddWorker` - הוספת עובד חדש
- `GET /GetWorkerById/{id}` - חיפוש עובד לפי ID
- `DELETE /DeleteWorker/{id}` - מחיקת עובד

### הזמנות (Orders)
- `GET /GetOrders` - קבלת רשימת הזמנות
- `POST /AddOrder` - יצירת הזמנה חדשה
- `GET /GetOrderById/{id}` - חיפוש הזמנה לפי ID

## 🔐 אימות והרשאות

המערכת משתמשת ב-JWT Bearer Token לאימות. קיימות שתי רמות הרשאה:
- **Admin** - גישה מלאה לכל הפונקציות
- **SuperWorker** - גישה מוגבלת לפונקציות מסוימות

### קבלת Token
```http
POST /login
Content-Type: application/json

{
  "username": "your_username",
  "password": "your_password"
}
```

### שימוש ב-Token
```http
GET /api/endpoint
Authorization: Bearer your_jwt_token
```

## 📝 קבצי נתונים

המערכת שומרת נתונים בקבצי JSON:
- `JsonConvert.json` - נתוני פיצות
- `worker.json` - נתוני עובדים
- `Actionlog.txt` - לוג פעולות

## 🧪 בדיקות

הפרויקט כולל:
- Middleware לטיפול בשגיאות
- Validation לפרמטרים
- Logging של פעולות
- Error handling מתקדם

## 👨‍💻 פיתוח

### הוספת Controller חדש
1. צור קובץ חדש ב-`Controllers/`
2. ירש מ-`baseControllers`
3. הוסף את ה-Controller ל-DI Container ב-`Program.cs`

### הוספת מודל חדש
1. צור קובץ חדש ב-`models/`
2. הוסף את המודל ל-Interface המתאים
3. עדכן את השירותים הרלוונטיים

## 📞 תמיכה

לשאלות ותמיכה טכנית, פנה אל:
- Email: [your-email@example.com]
- GitHub Issues: [repository-issues]

## 📄 רישיון

פרויקט זה פותח כחלק מקורס פיתוח Web API.

---

**פותח על ידי:** [שם המפתח]  
**תאריך:** 2024  
**גרסה:** 1.0.0

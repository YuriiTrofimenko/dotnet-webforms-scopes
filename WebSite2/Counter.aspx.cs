using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Counter : System.Web.UI.Page
{
    // Request Scope
    public int count = 0;
    public int visits = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Request Scope
        /* String countString = Request.QueryString["count"];
        if (countString != null) {
            count = Int32.Parse(countString);
        } */

        // Session Scope
        /* Object countInt = this.Session["count"];
        if (countInt != null)
        {
            count = (int)countInt;
        } */

        // Application Scope
        // запираем глобальный словарь Application
        // от доступа из других потоков выполнения
        Application.Lock();
        // пытаемся получить из Application значение под ключом visits
        Object visitsObject = Application["visits"];
        // если удалось - извлекаем его и сохраняем в локальное поле
        // объекта текущей страницы, чтобы отобразить на ней число посещений
        // с уникальных браузеров
        if (visitsObject != null)
        {
            visits = (int)visitsObject;
        }
        // если данный клиент еще не увеличивал visits на 1
        if (Session["sessionId"] == null)
        {
            // генерируем уникальный ИД
            // и сохраняем его в сессионном массиве под ключом sessionId
            Session["sessionId"] = Guid.NewGuid();
            // увеличиваем значение локального поля visits на 1
            visits++;
            // и сохраняем в Application
            Application["visits"] = visits;
        }
        // отприаем глобальный словарь Application
        // для доступа из других потоков выполнения
        Application.UnLock();
    }

    protected void increment_Click(object sender, EventArgs e)
    {
        // count++;
        // ViewState Scope
        /* Object obj = this.ViewState["count"];
        if (obj != null)
        {
            count = (int)obj;
        }
        count += 1;
        this.ViewState["count"] = count; */

        // Request Scope
        /* count++;
        Response.Redirect($"Counter.aspx?sender={this.GetType().Name}&count={count}"); */

        // Session Scope
        count++;
        this.Session["count"] = count;
    }

    protected void send_Click(object sender, EventArgs e)
    {
        Response.Redirect($"Receiver.aspx?sender={this.GetType().Name}&count={this.ViewState["count"]}");
    }
}
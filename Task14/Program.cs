// Урок 3. PLINQ и асинхронность: как работает, области применения
// Добавьте использование Cancellationtoken в код сервера, чтобы можно было правильно останавливать работу сервера.

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public class Server
{
    private CancellationTokenSource _cancellationTokenSource;

    public void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        
        Task.Run(() => StartListening(_cancellationTokenSource.Token));
    }

    public void Stop()
    {
        _cancellationTokenSource?.Cancel();
    }

    private void StartListening(CancellationToken cancellationToken)
    {
        TcpListener tcpListener = new TcpListener(IPAddress.Any, 1234);

        tcpListener.Start();

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                // Handle client connection
                Task.Run(() => HandleClient(tcpClient, cancellationToken));
            }
            catch (SocketException)
            {
                // Handle exception
            }
        }

        tcpListener.Stop();
    }

    private void HandleClient(TcpClient tcpClient, CancellationToken cancellationToken)
    {
        // Handle client communication
    }
}

public class Program
{
    public static void Main()
    {
        Server server = new Server();
        server.Start();

        // Simulate server running for some time
        Thread.Sleep(5000);

        server.Stop();
    }
}

// В этом фрагменте кода я добавил использование CancellationToken в код сервера. 
// Теперь класс Server включает поле CancellationTokenSource для управления маркером отмены. 
// Метод Start инициализирует CancellationTokenSource и запускает новую задачу для выполнения метода StartListening. 
// Метод Stop отменяет маркер при вызове.

// Метод StartListening прослушивает входящие соединения на определенном порту с помощью TcpListener. 
// Внутри цикла он принимает входящих клиентов и обрабатывает каждое клиентское соединение в отдельной задаче с помощью метода HandleClient. 
// Цикл продолжается до тех пор, пока токен отмены не подаст сигнал об отмене.

// Метод HandleClient представляет собой логику обработки клиентских соединений, которая может быть 
// настроена в соответствии с требованиями приложения.

// Наконец, метод Main класса Program создает экземпляр класса Server, запускает сервер, имитирует его работу
// в течение некоторого времени и останавливает сервер, вызывая метод Stop.


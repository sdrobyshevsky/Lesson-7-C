// Разработка сетевого приложения на C# (семинары)
// Урок 6. Тестирование приложений: test driven development
// Продумайте, как можно протестировать код клиента по аналогии с кодом сервера.

// Когда мы разрабатываем клиентское приложение, мы можем протестировать его с использованием техники Test Driven Development (TDD), точно так же как и серверное приложение.
// Например, мы можем написать тесты на функции и методы клиента, чтобы проверить их правильность перед написанием реализации.

using System;
using Xunit;

public class ClientTests
{
    [Fact]
    public void CanConnectToServer()
    {
        // Arrange
        Client client = new Client();
        
        // Act
        bool isConnected = client.ConnectToServer("192.168.1.1");
        
        // Assert
        Assert.True(isConnected);
    }
    
    [Fact]
    public void CanSendDataToServer()
    {
        // Arrange
        Client client = new Client();
        
        // Act
        bool isDataSent = client.SendDataToServer("Hello, server!");
        
        // Assert
        Assert.True(isDataSent);
    }
}

public class Client
{
    public bool ConnectToServer(string serverIP)
    {
        // Реализация подключения к серверу
        return true;
    }
    
    public bool SendDataToServer(string data)
    {
        // Реализация отправки данных на сервер
        return true;
    }
}


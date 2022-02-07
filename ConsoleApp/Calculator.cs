﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.9157
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ICalculator")]
public interface ICalculator
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Add", ReplyAction="http://tempuri.org/ICalculator/AddResponse")]
    float Add(float a, float b);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Sub", ReplyAction="http://tempuri.org/ICalculator/SubResponse")]
    float Sub(float a, float b);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Mul", ReplyAction="http://tempuri.org/ICalculator/MulResponse")]
    float Mul(float a, float b);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Div", ReplyAction="http://tempuri.org/ICalculator/DivResponse")]
    float Div(float a, float b);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
{
    
    public CalculatorClient()
    {
    }
    
    public CalculatorClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public float Add(float a, float b)
    {
        return base.Channel.Add(a, b);
    }
    
    public float Sub(float a, float b)
    {
        return base.Channel.Sub(a, b);
    }
    
    public float Mul(float a, float b)
    {
        return base.Channel.Mul(a, b);
    }
    
    public float Div(float a, float b)
    {
        return base.Channel.Div(a, b);
    }
}

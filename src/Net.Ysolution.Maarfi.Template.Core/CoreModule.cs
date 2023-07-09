using Autofac;
using AutoMapper;
using Net.Ysolution.Maarfi.Template.Core.Interfaces;
using Net.Ysolution.Maarfi.Template.Core.Services;
using Net.Ysolution.Maarfi.Shared.Core.Commands;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Net.Ysolution.Maarfi.Template.Core.Handlers;
using MediatR;
using Net.Ysolution.Maarfi.Template.Core.Services.Dto.AddUser;
using Net.Ysolution.Maarfi.Template.Core.Resources;
using Net.Ysolution.Maarfi.Template.Core.Dto;

namespace Net.Ysolution.Maarfi.Template.Core;

public class CoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    
    // Register services
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
    builder.RegisterType<AddUserUserStroy>().As(typeof(IUserStory<AddUserRequest, AddUserResponse>)).InstancePerLifetimeScope();
    builder.RegisterType<QueryUserUserStroy>().As(typeof(IUserStory<QueryUserRequest, QueryUserResponse>)).InstancePerLifetimeScope();
    builder.RegisterType<UpdateUserUserStroy>().As(typeof(IUserStory<UpdateUserRequest, UpdateUserResponse>)).InstancePerLifetimeScope();
    //Register handler
    builder
       .RegisterType<GetUserByIdHandler>()
       .As<IRequestHandler<GetUserByIdCommand, UserDto>>()
       .InstancePerLifetimeScope();
    
    builder.RegisterType<LocalizeService>().SingleInstance();


  }
}

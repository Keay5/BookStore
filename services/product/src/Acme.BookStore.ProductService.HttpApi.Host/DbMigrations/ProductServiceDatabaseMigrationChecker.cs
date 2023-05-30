﻿using System;
using Microsoft.Extensions.Logging;
using Acme.BookStore.ProductService.EntityFrameworkCore;
using Acme.BookStore.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Acme.BookStore.ProductService.DbMigrations;

public class ProductServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<ProductServiceDbContext>
{
    public ProductServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock) : base(
        loggerFactory,
        unitOfWorkManager,
        serviceProvider,
        currentTenant,
        distributedEventBus,
        abpDistributedLock,
        ProductServiceDbProperties.ConnectionStringName)
    {
    }
}

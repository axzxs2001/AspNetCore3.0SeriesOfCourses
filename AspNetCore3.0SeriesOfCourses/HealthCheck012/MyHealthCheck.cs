using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HealthCheck012
{
    /// <summary>
    /// 自定义健康检查
    /// </summary>
    public class MyHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            return Task.FromResult(HealthCheckResult.Unhealthy("不健康"));
        }
    }
    /// <summary>
    /// 健康检查扩展
    /// </summary>
    public static class MyHealthCheckExtion
    {
        public static IHealthChecksBuilder AddMyHealthCheck(this IHealthChecksBuilder healthChecksBuilder)
        {
            healthChecksBuilder.AddCheck<MyHealthCheck>("myhealthcheck", HealthStatus.Healthy);
            return healthChecksBuilder;
        }
    }
}

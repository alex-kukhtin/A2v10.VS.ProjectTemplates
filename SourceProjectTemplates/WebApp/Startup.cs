﻿// Copyright © 2024 Oleksandr Kukhtin. All rights reserved.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using A2v10.ReportEngine.Pdf;

namespace $safeprojectname$;

public class Startup(IConfiguration configuration)
{
	public IConfiguration Configuration { get; } = configuration;

	public void ConfigureServices(IServiceCollection services)
	{
		services.UseAppRuntimeBuilder(); // Before platform!

		services.UsePlatform(Configuration);

		services.AddReportEngines(factory =>
		{
			factory.RegisterEngine<PdfReportEngine>("pdf");
		});
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		app.ConfigurePlatform(env, Configuration);
	}
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


#region - Routing


app.MapControllerRoute(
    name: "MovieDetails",
    pattern: "Movies/{movieId}",
    defaults: new { Controller = "Movies", Action = "ShowMovie" });

app.MapControllerRoute(
    name: "ActorDetails",
    pattern: "People/{actorId}",
    defaults: new { Controller = "People", Action = "ShowActorMovies" });

app.MapControllerRoute(
    name: "DirectorDetails",
    pattern: "People/{directorId}",
    defaults: new { Controller = "People", Action = "ShowDirectorMovies" });

app.MapControllerRoute(
    name: "AllDirectors",
    pattern: "Directors",
    defaults: new { Controller = "People", Action = "ShowDirectors" });

app.MapControllerRoute(
    name: "AllActors",
    pattern: "Actors",
    defaults: new { Controller = "People", Action = "ShowActors" });

app.MapDefaultControllerRoute();
#endregion


app.Run();

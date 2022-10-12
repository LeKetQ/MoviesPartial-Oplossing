var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

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
    name: "AllMovies",
    pattern: "Movies/All",
    defaults: new { Controller = "Movies", Action = "Index" });

app.MapControllerRoute(
    name: "AllDirectors",
    pattern: "Directors/All",
    defaults: new { Controller = "People", Action = "ShowDirectors" });

app.MapControllerRoute(
    name: "AllActors",
    pattern: "Actors/All",
    defaults: new { Controller = "People", Action = "ShowActors" });

/*
app.MapControllerRoute(
   name: "MovieInfo",
   pattern: "Movies/{id:long?}",
   defaults: new { Controller = "Home", Action = "ShowMovieInfo" });
*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

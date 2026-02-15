using Asp.NetHw5.Models;

namespace Asp.NetHw5.Parts
{
    public class HtmlParts
    {
        public static string RenderPage(string body, string query = "")
        {
            return
                $"""
                <!DOCTYPE html>
                <html lang="en">
                <head>
                	<meta charset="utf-8">
                	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

                	<!-- CSS -->
                	{RenderCssSection()}
                	{RenderMetaSection()}
                </head>
                <body class="body">
                    {RenderHeaderSection(query)}
                    {body}
                    {RenderFooterSection()}
                    {RenderScriptsSection()}
                </body>
                </html>
                """;
        }

        public static string RenderMovieList(IEnumerable<Movie> movies)
        {
            return
                $"""
                <section class="content">
                    <div class="container">
                        <div class="row">
                            {string.Join("", movies.Select((Movie movie) => RenderMovieCard(movie)))}
                        </div>
                    </div>
                </section>
                """;
        }
        static string RenderMovieCard(Movie movie)
        {
            return 
                $"""
                <div class="col-6 col-sm-4 col-lg-3 col-xl-2">
                    <div class="item">
                		<div class="item__cover">
                			<img src="https://image.tmdb.org/t/p/w500{movie.PosterPath}" alt="Movie cover">
                			<a href="/details/Id={movie.Id}" class="item__play">
                				<i class="ti ti-player-play-filled"></i>
                			</a>
                			<span class="item__rate item__rate--green">{movie.VoteAverage}</span>
                			<button class="item__favorite" type="button"><i class="ti ti-bookmark"></i></button>
                		</div>
                		<div class="item__content">
                			<h3 class="item__title"><a href="/details/Id={movie.Id}">{movie.Title}</a></h3>
                			<span class="item__category">
                				<a href="#">Action</a>
                				<a href="#">Triler</a>
                			</span>
                		</div>
                	</div>
                </div>
                """;
        }

        public static string RenderMovieDetails(MovieDetails movie, IEnumerable<Movie> similarMovies)
        {
            string genresHtml = movie.Genres != null
                ? string.Join("\n", movie.Genres.Select(g => $"<a href=\"#\">{g.Name}</a>"))
                : "";

            string countriesHtml = movie.ProductionCountries != null
                ? string.Join(", ", movie.ProductionCountries.Select(c => c.Name))
                : "Unknown";

            string trailerKey = movie.Videos?.Results?
                                            .FirstOrDefault(v => v.Site == "YouTube" && v.Type == "Trailer")?.Key ?? "";

            string playerHtml = !string.IsNullOrEmpty(trailerKey)
                ? $"<iframe width=\"100%\" height=\"100%\" style=\"aspect-ratio: 16/9; border-radius: 8px;\" src=\"https://www.youtube.com/embed/{trailerKey}\" frameborder=\"0\" allowfullscreen></iframe>"
                : "<div style=\"padding: 50px; text-align: center; color: white; background: #1a1a1a; border-radius: 8px;\">Трейлер не найден</div>";

            string similarMoviesHtml = string.Join("\n", similarMovies.Select(sm => 
            $"""
            <div class="col-6 col-sm-4 col-lg-3 col-xl-2">
                <div class="item">
                    <div class="item__cover">
                        <img src="https://image.tmdb.org/t/p/w500{sm.PosterPath}" alt="">
                        <a href="/details/Id={sm.Id}" class="item__play">
                            <i class="ti ti-player-play-filled"></i>
                        </a>
                        <span class="item__rate item__rate--green">{sm.VoteAverage:F1}</span>
                        <button class="item__favorite" type="button"><i class="ti ti-bookmark"></i></button>
                    </div>
                    <div class="item__content">
                        <h3 class="item__title"><a href="/details/Id={sm.Id}">{sm.Title}</a></h3>
                    </div>
                </div>
            </div>
            """));

            string body = 
                $"""
                <section class="section section--details">
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <h1 class="section__title section__title--head">{movie.Title}</h1>
                            </div>
                            <div class="col-12">
                                <div class="item item--details">
                                    <div class="row">
                                        <div class="col-12 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                                            <div class="item__cover">
                                                <img src="https://image.tmdb.org/t/p/w500{movie.PosterPath}" alt="">
                                                <span class="item__rate item__rate--green">{movie.VoteAverage:F1}</span>
                                                <button class="item__favorite item__favorite--static" type="button"><i class="ti ti-bookmark"></i></button>
                                            </div>
                                        </div>
                                        <div class="col-12 col-sm-8 col-md-8 col-lg-9 col-xl-9">
                                            <div class="item__content">
                                                <ul class="item__meta">
                                                    <li><span>Genre:</span> {genresHtml}</li>
                                                    <li><span>Premiere:</span> {movie.ReleaseDate}</li>
                                                    <li><span>Running time:</span> {movie.Runtime} min</li>
                                                    <li><span>Country:</span> {countriesHtml}</li>
                                                </ul>
                                                <div class="item__description" style="max-height: none; overflow: visible;">
                                                    <p>{movie.Overview}</p>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                </div>
                            </div>
                            <div class="col-12" style="margin-top: 30px;">
                                {playerHtml}
                            </div>
                            </div>
                    </div>
                </section>

                <section class="content">
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <h2 class="section__title">You may also like...</h2>
                            </div>
                    
                            {similarMoviesHtml}

                        </div>
                    </div>
                </section>
            """;

            return RenderPage(body);
        }

        static string RenderCssSection()
        {
            return
                $"""
        <link rel="stylesheet" href="/css/bootstrap.min.css">
        <link rel="stylesheet" href="/css/splide.min.css">
        <link rel="stylesheet" href="/css/slimselect.css">
        <link rel="stylesheet" href="/css/plyr.css">
        <link rel="stylesheet" href="/css/photoswipe.css">
        <link rel="stylesheet" href="/css/default-skin.css">
        <link rel="stylesheet" href="/css/main.css">
        """;
        }

        static string RenderMetaSection(string title = "HotFlix")
        {
            return
                $"""
        <link rel="stylesheet" href="/webfont/tabler-icons.min.css">

        <link rel="icon" type="image/png" href="/icon/favicon-32x32.png" sizes="32x32">
        <link rel="apple-touch-icon" href="/icon/favicon-32x32.png">

        <meta name="description" content="">
        <meta name="keywords" content="">
        <meta name="author" content="">
        <title>{title}</title>
        """;
        }

        static string RenderScriptsSection()
        {
            return
                """
        <script src="/js/bootstrap.bundle.min.js"></script>
        <script src="/js/splide.min.js"></script>
        <script src="/js/slimselect.min.js"></script>
        <script src="/js/smooth-scrollbar.js"></script>
        <script src="/js/plyr.min.js"></script>
        <script src="/js/photoswipe.min.js"></script>
        <script src="/js/photoswipe-ui-default.min.js"></script>
        <script src="/js/main.js"></script>
        """;
        }

        static string RenderHeaderSection(string query = "")
        {
            return
                $"""
        <header class="header">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="header__content">
                            <a href="/" class="header__logo">
                                <img src="/img/logo.svg" alt="">
                            </a>
                            <ul class="header__nav">
                                <li class="header__nav-item">
                                    <a class="header__nav-link" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Home <i class="ti ti-chevron-down"></i></a>
                                </li>
                            </ul>
                            <div class="header__auth">
                                <form action="/search" class="header__search" method="get">
                                    <input class="header__search-input" type="text" placeholder="Search..." name="query" value="{query}">
                                    <button class="header__search-button" type="submit">
                                        <i class="ti ti-search"></i>
                                    </button>
                                    <button class="header__search-close" type="button">
                                        <i class="ti ti-x"></i>
                                    </button>
                                </form>

                                <button class="header__search-btn" type="button">
                                    <i class="ti ti-search"></i>
                                </button>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        """;
        }

        static string RenderFooterSection()
        {
            return 
                $"""
                <footer class="footer">
                	<div class="container">
                		<div class="row">
                			<div class="col-12">
                				<div class="footer__content">
                					<a href="index.html" class="footer__logo">
                						<img src="img/logo.svg" alt="">
                					</a>

                					<span class="footer__copyright">© HOTFLIX, 2019—2024 <br> Create by <a href="https://themeforest.net/user/dmitryvolkov/portfolio" target="_blank">Dmitry Volkov</a></span>

                					<nav class="footer__nav">
                						<a href="about.html">About Us</a>
                						<a href="contacts.html">Contacts</a>
                						<a href="privacy.html">Privacy policy</a>
                					</nav>

                					<button class="footer__back" type="button">
                						<i class="ti ti-arrow-narrow-up"></i>
                					</button>
                				</div>
                			</div>
                		</div>
                	</div>
                </footer>
                """;
        }
    }
}

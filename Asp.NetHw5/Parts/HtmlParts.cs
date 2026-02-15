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

        public static string RenderMovieDetails(Movie movie)
        {
            string body = $"""
                <section class="section section--details">
                	<!-- details content -->
                	<div class="container">
                		<div class="row">
                			<!-- title -->
                			<div class="col-12">
                				<h1 class="section__title section__title--head">{movie.Title}</h1>
                			</div>
                			<!-- end title -->

                			<!-- content -->
                			<div class="col-12 col-xl-6">
                				<div class="item item--details">
                					<div class="row">
                						<!-- card cover -->
                						<div class="col-12 col-sm-5 col-md-5 col-lg-4 col-xl-6 col-xxl-5">
                							<div class="item__cover">
                								<img src="https://image.tmdb.org/t/p/w500{movie.PosterPath}" alt="">
                								<span class="item__rate item__rate--green">{movie.VoteAverage}</span>
                								<button class="item__favorite item__favorite--static" type="button"><i class="ti ti-bookmark"></i></button>
                							</div>
                						</div>
                						<!-- end card cover -->

                						<!-- card content -->
                						<div class="col-12 col-md-7 col-lg-8 col-xl-6 col-xxl-7">
                							<div class="item__content">
                								<ul class="item__meta">
                									<li><span>Director:</span> <a href="actor.html">Vince Gilligan</a></li>
                									<li><span>Cast:</span> <a href="actor.html">Brian Cranston</a> <a href="actor.html">Jesse Plemons</a> <a href="actor.html">Matt Jones</a> <a href="actor.html">Jonathan Banks</a> <a href="actor.html">Charles Baker</a> <a href="actor.html">Tess Harper</a></li>
                									<li><span>Genre:</span> <a href="catalog.html">Action</a>
                									<a href="catalog.html">Triler</a></li>
                									<li><span>Premiere::</span> 2019</li>
                									<li><span>Running time:</span> 128 min</li>
                									<li><span>Country:</span> <a href="catalog.html">USA</a></li>
                								</ul>

                								<div class="item__description">
                									<p{movie.Overview}</p>
                								</div>
                							</div>
                						</div>
                						<!-- end card content -->
                					</div>
                				</div>
                			</div>
                			<!-- end content -->

                			<!-- player -->
                			<div class="col-12 col-xl-6">
                				<video controls crossorigin playsinline poster="https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-HD.jpg" id="player">
                					<!-- Video files -->
                					<source src="https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-576p.mp4" type="video/mp4" size="576">
                					<source src="https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-720p.mp4" type="video/mp4" size="720">
                					<source src="https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-1080p.mp4" type="video/mp4" size="1080">

                					<!-- Caption files -->
                					<track kind="captions" label="English" srclang="en" src="https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-HD.en.vtt"
                						default>
                					<track kind="captions" label="Français" srclang="fr" src="https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-HD.fr.vtt">

                					<!-- Fallback for browsers that don't support the <video> element -->
                					<a href="https://cdn.plyr.io/static/demo/View_From_A_Blue_Moon_Trailer-576p.mp4" download>Download</a>
                				</video>
                			</div>
                			<!-- end player -->
                		</div>
                	</div>
                	<!-- end details content -->
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

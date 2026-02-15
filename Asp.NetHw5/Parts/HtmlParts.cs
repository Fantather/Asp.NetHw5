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
                			<a href="details.html" class="item__play">
                				<i class="ti ti-player-play-filled"></i>
                			</a>
                			<span class="item__rate item__rate--green">{movie.VoteAverage}</span>
                			<button class="item__favorite" type="button"><i class="ti ti-bookmark"></i></button>
                		</div>
                		<div class="item__content">
                			<h3 class="item__title"><a href="details.html">{movie.Title}</a></h3>
                			<span class="item__category">
                				<a href="#">Action</a>
                				<a href="#">Triler</a>
                			</span>
                		</div>
                	</div>
                </div>
                """;
        }

        static string RenderCssSection()
        {
            return
                $"""
                <link rel="stylesheet" href="css/bootstrap.min.css">
                <link rel="stylesheet" href="css/splide.min.css">
                <link rel="stylesheet" href="css/slimselect.css">
                <link rel="stylesheet" href="css/plyr.css">
                <link rel="stylesheet" href="css/photoswipe.css">
                <link rel="stylesheet" href="css/default-skin.css">
                <link rel="stylesheet" href="css/main.css">
                """;
        }

        static string RenderMetaSection(string title = "HotFlix")
        {
            return
                $"""
                <!-- Icon font -->
                <link rel="stylesheet" href="webfont/tabler-icons.min.css">

                <!-- Favicons -->
                <link rel="icon" type="image/png" href="icon/favicon-32x32.png" sizes="32x32">
                <link rel="apple-touch-icon" href="icon/favicon-32x32.png">

                <meta name="description" content="">
                <meta name="keywords" content="">
                <meta name="author" content="">
                <title>{title}</title>
                """;
        }

        static string RenderHeaderSection(string query)
        {
            return
                $"""
                <!-- header -->
                <header class="header">
                	<div class="container">
                		<div class="row">
                			<div class="col-12">
                				<div class="header__content">
                					<!-- header logo -->
                					<a href="index.html" class="header__logo">
                						<img src="img/logo.svg" alt="">
                					</a>
                					<!-- end header logo -->

                					<!-- header nav -->
                					<ul class="header__nav">
                						<!-- dropdown -->
                						<li class="header__nav-item">
                							<a class="header__nav-link" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Home <i class="ti ti-chevron-down"></i></a>

                							<ul class="dropdown-menu header__dropdown-menu">
                								<li><a href="index.html">Home style 1</a></li>
                								<li><a href="index2.html">Home style 2</a></li>
                								<li><a href="index3.html">Home style 3</a></li>
                							</ul>
                						</li>
                						<!-- end dropdown -->

                						<!-- dropdown -->
                						<li class="header__nav-item">
                							<a class="header__nav-link" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Catalog <i class="ti ti-chevron-down"></i></a>

                							<ul class="dropdown-menu header__dropdown-menu">
                								<li><a href="catalog.html">Catalog style 1</a></li>
                								<li><a href="catalog2.html">Catalog style 2</a></li>
                								<li><a href="details.html">Details Movie</a></li>
                								<li><a href="details2.html">Details TV Series</a></li>
                							</ul>
                						</li>
                						<!-- end dropdown -->

                						<li class="header__nav-item">
                							<a href="pricing.html" class="header__nav-link">Pricing plan</a>
                						</li>

                						<!-- dropdown -->
                						<li class="header__nav-item">
                							<a class="header__nav-link" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Pages <i class="ti ti-chevron-down"></i></a>

                							<ul class="dropdown-menu header__dropdown-menu">
                								<li><a href="about.html">About Us</a></li>
                								<li><a href="profile.html">Profile</a></li>
                								<li><a href="actor.html">Actor</a></li>
                								<li><a href="contacts.html">Contacts</a></li>
                								<li><a href="faq.html">Help center</a></li>
                								<li><a href="privacy.html">Privacy policy</a></li>
                								<li><a href="../admin/index.html" target="_blank">Admin pages</a></li>
                							</ul>
                						</li>
                						<!-- end dropdown -->

                						<!-- dropdown -->
                						<li class="header__nav-item">
                							<a class="header__nav-link header__nav-link--more" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false"><i class="ti ti-dots"></i></a>

                							<ul class="dropdown-menu header__dropdown-menu">
                								<li><a href="signin.html">Sign in</a></li>
                								<li><a href="signup.html">Sign up</a></li>
                								<li><a href="forgot.html">Forgot password</a></li>
                								<li><a href="404.html">404 Page</a></li>
                							</ul>
                						</li>
                						<!-- end dropdown -->
                					</ul>
                					<!-- end header nav -->

                					<!-- header auth -->
                					<div class="header__auth">
                						<form action="/search" class="header__search">
                							<input class="header__search-input" type="text" placeholder="Search..." 
                                            name="query" value="{query}">
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

                						<!-- dropdown -->
                						<div class="header__lang">
                							<a class="header__nav-link" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">EN <i class="ti ti-chevron-down"></i></a>

                							<ul class="dropdown-menu header__dropdown-menu">
                								<li><a href="#">English</a></li>
                								<li><a href="#">Spanish</a></li>
                								<li><a href="#">French</a></li>
                							</ul>
                						</div>
                						<!-- end dropdown -->

                						<!-- dropdown -->
                						<div class="header__profile">
                							<a class="header__sign-in header__sign-in--user" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                								<i class="ti ti-user"></i>
                								<span>Nickname</span>
                							</a>

                							<ul class="dropdown-menu dropdown-menu-end header__dropdown-menu header__dropdown-menu--user">
                								<li><a href="profile.html"><i class="ti ti-ghost"></i>Profile</a></li>
                								<li><a href="profile.html"><i class="ti ti-stereo-glasses"></i>Subscription</a></li>
                								<li><a href="profile.html"><i class="ti ti-bookmark"></i>Favorites</a></li>
                								<li><a href="profile.html"><i class="ti ti-settings"></i>Settings</a></li>
                								<li><a href="#"><i class="ti ti-logout"></i>Logout</a></li>
                							</ul>
                						</div>
                						<!-- end dropdown -->
                					</div>
                					<!-- end header auth -->

                					<!-- header menu btn -->
                					<button class="header__btn" type="button">
                						<span></span>
                						<span></span>
                						<span></span>
                					</button>
                					<!-- end header menu btn -->
                				</div>
                			</div>
                		</div>
                	</div>
                </header>
                """;
        }

        static string RenderScriptsSection()
        {
            return
                """
                <script src="js/bootstrap.bundle.min.js"></script>
                <script src="js/splide.min.js"></script>
                <script src="js/slimselect.min.js"></script>
                <script src="js/smooth-scrollbar.js"></script>
                <script src="js/plyr.min.js"></script>
                <script src="js/photoswipe.min.js"></script>
                <script src="js/photoswipe-ui-default.min.js"></script>
                <script src="js/main.js"></script>
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

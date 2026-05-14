// Navbar scroll effect: transparent at top, navy when scrolled
(function () {
    var navbar = document.querySelector('.sp-navbar');
    if (!navbar) return;

    function updateNavbar() {
        if (window.scrollY > 40) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }
    }

    window.addEventListener('scroll', updateNavbar, { passive: true });
    updateNavbar();
}());

// Smooth scroll for in-page anchor links
document.querySelectorAll('a[href^="#"]').forEach(function (link) {
    link.addEventListener('click', function (e) {
        var href = this.getAttribute('href');
        if (href === '#') return;
        var target = document.querySelector(href);
        if (!target) return;
        e.preventDefault();
        var offset = 80;
        var top = target.getBoundingClientRect().top + window.scrollY - offset;
        window.scrollTo({ top: top, behavior: 'smooth' });
    });
});

// Intersection Observer for fade-in animations
(function () {
    var elements = document.querySelectorAll('.sp-fade-in');
    if (!elements.length || !('IntersectionObserver' in window)) {
        elements.forEach(function (el) { el.classList.add('visible'); });
        return;
    }

    var observer = new IntersectionObserver(function (entries) {
        entries.forEach(function (entry) {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.12 });

    elements.forEach(function (el) { observer.observe(el); });
}());

// Translation key debug toggle (kept for development)
function toggleTKeys() {
    var active = document.body.classList.toggle('show-tkeys');
    var show = document.getElementById('tkey-show');
    var hide = document.getElementById('tkey-hide');
    if (show) show.style.display = active ? 'none' : '';
    if (hide) hide.style.display = active ? '' : 'none';
}

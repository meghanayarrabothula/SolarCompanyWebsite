// Smooth scrolling for navigation links
document.querySelectorAll("nav a").forEach(link => {
    link.addEventListener("click", function (e) {
        e.preventDefault();
        const href = this.getAttribute("href");
        if (href.startsWith("#")) {
            document.querySelector(href).scrollIntoView({ behavior: "smooth" });
        } else {
            window.location.href = href;
        }
    });
});

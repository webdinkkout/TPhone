$(document).ready(function () {
    const parentItem = $("p.sidebar__link");
    parentItem.click(function () {
        const icon = $(this).children("i.bi-caret-down");
        const sidebarItem = $(this).closest(".sidebar__item");

        if (icon.hasClass("sidebar__drop-icon")) {
            icon.removeClass("sidebar__drop-icon");
            sidebarItem.find("ul").removeClass("active");
        } else {
            icon.addClass("sidebar__drop-icon");
            sidebarItem.find("ul").addClass("active");
        }
    })
})
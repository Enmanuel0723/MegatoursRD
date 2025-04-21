window.bootstrapInterop = {
    abrirModal: function (selector) {
        const el = document.querySelector(selector);
        const modal = new bootstrap.Modal(el);
        modal.show();
    },
    cerrarModal: function (selector) {
        const el = document.querySelector(selector);
        const modal = bootstrap.Modal.getInstance(el);
        if (modal) modal.hide();
    }
};

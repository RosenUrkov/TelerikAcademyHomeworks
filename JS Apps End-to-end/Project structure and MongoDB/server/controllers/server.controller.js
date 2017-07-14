const serverController = ({ itemData }) => {
    return {
        home(req, res) {
            itemData.all()
                .then((data) => res.render('home', { context: data }));
        },
        flash(req, res) {
            req.flash('info', 'flash message');
            res.render('flash');
        },
    };
};

module.exports = serverController;

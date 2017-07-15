const serverController = ({ itemData }) => {
    return {
        redirectHome(req, res) {
            res.redirect('/home');
        },
        home(req, res) {
            res.render('home');
        },
        flash(req, res) {
            req.flash('error', 'custom flash message');
            res.render('flash');
        },
        showItems(req, res) {
            if (!req.query.color) {
                itemData.all()
                    .then((data) => res.render('items', { context: data }));
            } else {
                itemData.filter(req.query)
                    .then((data) => res.render('items', { context: data }));
            }
        },
        addItem(req, res) {
            const item = req.body;
            itemData.add(item)
                .then(() => req.flash('info', 'Item added successfully!'))
                .then(() => res.redirect('/items'));
        },
    };
};

module.exports = serverController;

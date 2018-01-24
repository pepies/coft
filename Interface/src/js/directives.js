/**
 * Created by pepies on 19.11.2016.
 */
app.directive('errSrc', function() {
    return {
        link: function(scope, element, attrs) {
            element.bind('error', function() {
                if (attrs.ngSrc != attrs.errSrc) {
                    attrs.$set('ngSrc', attrs.errSrc);
                }
            });
        }
    }
});
module.exports = function(grunt) {

require('load-grunt-tasks')(grunt);

grunt.initConfig({
	tmp: ['src/css/style.css', 'src/css/calendar.css', 'src/css/animations.css'],
	pkg: grunt.file.readJSON('package.json'),
	sass: {
		dist: {
			files: {
				'src/css/style.css': ['src/sass/style.scss'],
				'src/css/calendar.css': ['src/sass/calendar.scss'],
				'src/css/animations.css': ['src/sass/animations.scss']
			}
		},
		sourcemap: 'none'
	},
	cssmin: {
	  options: {
	    shorthandCompacting: false,
	    roundingPrecision: -1
	  },
	  target: {
	    files: {
	      'src/css/style.min.css': '<%= tmp %>' 
	    }
	  }
	},
	wiredep: {
	  task: {
	    src: ['src/home.php', 'src/index.php']
	  }
	},
	remove: {
		css: {
			options: {
		      trace: true
		    },
		    fileList: '<%= tmp %>'
		}
	},
    watch: {
    	task1: {
    		files: ['bower_components/*'],
  			tasks: ['wiredep']
    	},
    	task2: {	
		    files: ['src/sass/*.scss'],
		    tasks: ['sass', 'cssmin', 'remove'],
    	}
    }
  });
 
 	
};
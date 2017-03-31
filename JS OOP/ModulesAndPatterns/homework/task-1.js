/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 V * The course has a title and presentations
 V * Each presentation also has a title
 V * There is a homework for each presentation
 V * There is a set of students listed for the course
 V * Each student has firstname, lastname and an ID
 V * IDs must be unique integer numbers which are at least 1
 V * Each student can submit a homework for each presentation in the course
 V * Create method init
 V * Accepts a string - course title
 V * Accepts an array of strings - presentation titles
 V * Throws if there is an invalid title
 V * Titles do not start or end with spaces
 V * Titles do not have consecutive spaces
 V * Titles have at least one character
 V * Throws if there are no presentations
 V * Create method addStudent which lists a student for the course
 V * Accepts a string in the format 'Firstname Lastname'
 V * Throws if any of the names are not valid
 V * Names start with an upper case letter
 V * All other symbols in the name (if any) are lowercase letters
 V * Generates a unique student ID and returns it
 V * Create method getAllStudents that returns an array of students in the format:
 V * {firstname: 'string', lastname: 'string', id: StudentID}
 V * Create method submitHomework
 V * Accepts studentID and homeworkID
 V * homeworkID 1 is for the first presentation
 V * homeworkID 2 is for the second one
 V * ...
 V * Throws if any of the IDs are invalid
 V * Create method pushExamResults
 V * Accepts an array of items in the format {StudentID: ..., Score: ...}
 V * StudentIDs which are not listed get 0 points
 V * Throw if there is an invalid StudentID
 V * Throw if same StudentID is given more than once ( he tried to cheat (: )
 V * Throw if Score is not a number
 V * Create method getTopStudents which returns an array of the top 10 performing students
 V * If there are less than 10, return them all
 C * Array must be sorted from best to worst 
 C * The final score that is used to calculate the top performing students is done as follows:
 C * 75% of the exam result
 C * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    var Course = (function() {
        var tit = '',
            presents,
            students;

        function initiate(title, presentations) {
            presents = [];
            students = [];

            checkTitle(title);
            tit = title;

            if (presentations.length === 0) {
                throw '';
            }
            for (let i = 0, length = presentations.length; i < length; i += 1) {
                checkTitle(presentations[i]);
            }
            presents = presentations;

            return this;

            function checkTitle(str) {
                let trimmed = str.trim(),
                    pattern = /( )\1+/g;

                if (str.length === 0 || trimmed.length !== str.length || pattern.test(trimmed)) {
                    throw '';
                }
            }
        }

        function addStudent(name) {
            let fullName = name.split(' ');
            if (fullName.length !== 2) {
                throw '';
            }

            checkName(fullName[0]);
            checkName(fullName[1]);

            students.push({
                firstname: fullName[0],
                id: students.length + 1,
                lastname: fullName[1]
            });

            return students.length;

            function checkName(name) {
                pattern = /^[A-Z][a-z]*$/g;
                if (!pattern.test(name)) {
                    throw '';
                }
            }
        }

        function listStudents() {
            var result = [];
            for (var student of students) {
                result.push({
                    firstname: student.firstname,
                    id: student.id,
                    lastname: student.lastname
                });
            }
            return result;
        }

        function submitHomework(studentID, homeworkID) {
            if ((homeworkID > presents.length || homeworkID < 1) ||
                (studentID > students.length || studentID < 1)) {
                throw '';
            }

            if (students[studentID - 1].homeworks !== undefined) {
                students[studentID - 1].homeworks += 1;
            } else {
                students[studentID - 1].homeworks = 1;
            }
        }

        function pushExamResults(results) {
            for (let res of results) {
                if ((isNaN(res.score) || isNaN(res.StudentID)) ||
                    (res.StudentID > students.length || res.StudentID < 1)) {
                    throw '';
                }

                if (students[res.StudentID - 1].score !== undefined) {
                    throw '';
                }

                students[res.StudentID - 1].score = res.score;
            }

            for (let i = 0, length = students.length; i < length; i += 1) {
                if (students[i].score === undefined) {
                    students[i].score = 0;
                }
            }
        }

        //may not work
        function getTopStudents() {
            var bestStudents = [],
                sortedStudents = [];

            for (let i = 0, length = students.length; i < length; i += 1) {
                if (students[i].homeworks === undefined) {
                    students[i].homeworks = 0;
                }
                students[i].finalScore = (3 / 4) * students[i].score + (1 / 4) * students[i].homeworks;
            }

            sortedStudents = students.sort((x, y) => x.finalScore - y.finalScore);

            for (let i = 0, length = (sortedStudents.length < 10 ? sortedStudents.length : 10); i < length; i += 1) {
                bestStudents.push(students[i]);
            }

            return bestStudents;
        }

        return {
            init: initiate,
            addStudent: addStudent,
            getAllStudents: listStudents,
            submitHomework: submitHomework,
            pushExamResults: pushExamResults,
            getTopStudents: getTopStudents
        };
    })();

    return Course;
}

module.exports = solve;
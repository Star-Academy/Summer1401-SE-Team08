namespace ControllerSpace;

using System;
using System.Collections.Generic;
using System.Linq;

using StudentSpace;
using ScoreSpace;


public class Controller {
	
	public List<Student> students {get; set;}
	public List<ScoreType> scores {get; set;}

	public Controller() {
		this.students = new List<Student>();
		this.scores = new List<ScoreType>();
	}

	public List<string> Methoddawd(){
		return students.Select(x => new {
				Average = scores.Where(y => y.StudentNumber == x.StudentNumber).Select(y => y.Score).Average(), St=x
				}).OrderByDescending(x => x.Average).Take(3).Select(
					x => "FirstName: " + x.St.FirstName + ", LastName: " + x.St.LastName + ", Average: " + x.Average).ToList();
	}
}
import { Component, OnInit } from '@angular/core';
import { DataService } from './../../services/data.service';

@Component({
    selector: 'app-posts',
    templateUrl: './posts.component.html',
    styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
    public posts: Post[];

    constructor(private readonly dataService: DataService) { }

    ngOnInit() {
        this.dataService.getPosts().subscribe(posts => this.posts = posts);
    }

}

interface Post {
    id: number;
    title: string;
    body: string;
    userId: number;
}

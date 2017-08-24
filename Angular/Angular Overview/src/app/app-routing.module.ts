import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserComponent } from './components/user/user.component';
import { ButtonComponent } from './components/button/button.component';
import { PostsComponent } from './components/posts/posts.component';

const routes: Routes = [
    {
        path: '',
        component: UserComponent,
    },
    {
        path: 'button',
        component: ButtonComponent,
    },
    {
        path: 'posts',
        component: PostsComponent,
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

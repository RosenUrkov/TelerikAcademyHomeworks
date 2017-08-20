import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { UserComponent } from './components/user/user.component';
import { ButtonComponent } from './components/button/button.component';
import { PostsComponent } from './components/posts/posts.component';

import { DataService } from './services/data.service';

@NgModule({
    declarations: [
        AppComponent,
        UserComponent,
        ButtonComponent,
        PostsComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        HttpModule
    ],
    providers: [DataService],
    bootstrap: [AppComponent]
})
export class AppModule { }

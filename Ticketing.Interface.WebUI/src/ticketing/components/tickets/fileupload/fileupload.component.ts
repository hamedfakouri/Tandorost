import { Component, EventEmitter, Output } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import {StartupService} from './../../../startupService'

@Component({
    selector: 'fileupload',
    templateUrl: './fileupload.component.html',
    styleUrls: ['./fileupload.component.css']
})
export class FileUploadComponent {
    public isUploadBtn: boolean = true;
    public fileUri: string;
    @Output()
    onUploadUri: EventEmitter<string> = new EventEmitter<string>();

    constructor(private http: Http) {
    }

    fileChange(event) {
        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            let file: File = fileList[0];
            let formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);

            let headers = new Headers();
            let options = new RequestOptions({ headers });
            this.http.post("api/UploadResources", formData, options)
                .catch(error => Observable.throw(error))
                .subscribe(
                data => {
                this.fileUri = data._body;
                this.onUploadUri.emit(this.fileUri);
                },
                    error =>alert(error) 
            );
        }
    }
}  
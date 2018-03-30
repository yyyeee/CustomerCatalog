/* tslint:disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v11.16.1.0 (NJsonSchema v9.10.41.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export class CustomerClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "http://localhost:2321";
    }

    getAll(): Promise<CustomerDto[] | null> {
        let url_ = this.baseUrl + "/api/Customer";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: new Headers({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAll(_response);
        });
    }

    protected processGetAll(response: Response): Promise<CustomerDto[] | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v, k) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (resultData200 && resultData200.constructor === Array) {
                result200 = [];
                for (let item of resultData200)
                    result200.push(CustomerDto.fromJS(item));
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<CustomerDto[] | null>(<any>null);
    }

    put(command: UpdateCustomerCommand | null): Promise<FileResponse | null> {
        let url_ = this.baseUrl + "/api/Customer";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ = <RequestInit>{
            body: content_,
            method: "PUT",
            headers: new Headers({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPut(_response);
        });
    }

    protected processPut(response: Response): Promise<FileResponse | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v, k) => _headers[k] = v); };
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return response.blob().then(blob => { return { fileName: fileName, data: blob, status: status, headers: _headers }; });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<FileResponse | null>(<any>null);
    }

    post(command: AddCustomerCommand | null): Promise<void> {
        let url_ = this.baseUrl + "/api/Customer";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: new Headers({
                "Content-Type": "application/json", 
            })
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPost(_response);
        });
    }

    protected processPost(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v, k) => _headers[k] = v); };
        if (status === 201) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(<any>null);
    }

    getNotes(id: string): Promise<NoteDto[] | null> {
        let url_ = this.baseUrl + "/api/Customer/note/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id)); 
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: new Headers({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetNotes(_response);
        });
    }

    protected processGetNotes(response: Response): Promise<NoteDto[] | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v, k) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (resultData200 && resultData200.constructor === Array) {
                result200 = [];
                for (let item of resultData200)
                    result200.push(NoteDto.fromJS(item));
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<NoteDto[] | null>(<any>null);
    }

    addNote(command: AddCustomerNoteCommand | null): Promise<void> {
        let url_ = this.baseUrl + "/api/Customer/note";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: new Headers({
                "Content-Type": "application/json", 
            })
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processAddNote(_response);
        });
    }

    protected processAddNote(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v, k) => _headers[k] = v); };
        if (status === 201) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(<any>null);
    }
}

export class CustomerDto implements ICustomerDto {
    id!: string;
    name?: string | undefined;
    status!: CustomerStatus;
    creationTime!: Date;

    constructor(data?: ICustomerDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
            this.status = data["status"];
            this.creationTime = data["creationTime"] ? new Date(data["creationTime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): CustomerDto {
        data = typeof data === 'object' ? data : {};
        let result = new CustomerDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["status"] = this.status;
        data["creationTime"] = this.creationTime ? this.creationTime.toISOString() : <any>undefined;
        return data; 
    }
}

export interface ICustomerDto {
    id: string;
    name?: string | undefined;
    status: CustomerStatus;
    creationTime: Date;
}

export enum CustomerStatus {
    Prospective = 1, 
    Current = 2, 
    NonActive = 3, 
}

export class NoteDto implements INoteDto {
    id!: string;
    text?: string | undefined;

    constructor(data?: INoteDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.text = data["text"];
        }
    }

    static fromJS(data: any): NoteDto {
        data = typeof data === 'object' ? data : {};
        let result = new NoteDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["text"] = this.text;
        return data; 
    }
}

export interface INoteDto {
    id: string;
    text?: string | undefined;
}

export class AddCustomerNoteCommand implements IAddCustomerNoteCommand {
    customerId!: string;
    id!: string;
    text?: string | undefined;

    constructor(data?: IAddCustomerNoteCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.customerId = data["customerId"];
            this.id = data["id"];
            this.text = data["text"];
        }
    }

    static fromJS(data: any): AddCustomerNoteCommand {
        data = typeof data === 'object' ? data : {};
        let result = new AddCustomerNoteCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["customerId"] = this.customerId;
        data["id"] = this.id;
        data["text"] = this.text;
        return data; 
    }
}

export interface IAddCustomerNoteCommand {
    customerId: string;
    id: string;
    text?: string | undefined;
}

export class UpdateCustomerCommand implements IUpdateCustomerCommand {
    id!: string;
    name?: string | undefined;
    status!: CustomerStatus;

    constructor(data?: IUpdateCustomerCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
            this.status = data["status"];
        }
    }

    static fromJS(data: any): UpdateCustomerCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateCustomerCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["status"] = this.status;
        return data; 
    }
}

export interface IUpdateCustomerCommand {
    id: string;
    name?: string | undefined;
    status: CustomerStatus;
}

export class AddCustomerCommand implements IAddCustomerCommand {
    id!: string;
    name?: string | undefined;

    constructor(data?: IAddCustomerCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
        }
    }

    static fromJS(data: any): AddCustomerCommand {
        data = typeof data === 'object' ? data : {};
        let result = new AddCustomerCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        return data; 
    }
}

export interface IAddCustomerCommand {
    id: string;
    name?: string | undefined;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class SwaggerException extends Error {
    message: string;
    status: number; 
    response: string; 
    headers: { [key: string]: any; };
    result: any; 

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if(result !== null && result !== undefined)
        throw result;
    else
        throw new SwaggerException(message, status, response, headers, null);
}
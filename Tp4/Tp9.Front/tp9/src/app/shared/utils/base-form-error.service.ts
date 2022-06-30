import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class BaseFormErrorService {

  private errorMessage: any;
  baseForm: FormGroup = new FormGroup({});
  constructor() { }

  isValidField(field: string): boolean {
    return (
      this.baseForm.get(field)!.touched || this.baseForm.get(field)!.dirty && !this.baseForm.get(field)!.valid
    )
  }

  getErrorMessage(field: string): string {

    const { errors }: any = this.baseForm.get(field);
    //console.log("errors -> ",errors);

    if (errors) {
      const minlength = errors?.minlength?.requiredLength;
      const maxlength = errors?.maxlength?.requiredLength;
      const min = errors?.min?.min;
      const messages: any = {
        required: 'Campo obligatorio',
        pattern: `No es un ${field} valido`,
        minlength: `Campo de minimo ${minlength} caracteres`,
        maxlength: `Campo de maximo ${maxlength} caracteres`,
        min: `Campo con valor minimo  de ${min}`,
      };

      const errorKey: any = Object.keys(errors).find(Boolean);

      this.errorMessage = messages[errorKey];
    } else {
      this.errorMessage = "";
    }
    return this.errorMessage;
  }
}

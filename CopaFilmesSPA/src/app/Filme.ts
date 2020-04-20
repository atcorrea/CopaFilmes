export class Filme{
    constructor(
        public id: string,
        public titulo: string,
        public ano: number,
        public nota: number,
        public selected: boolean = false
    ) {}
    
}
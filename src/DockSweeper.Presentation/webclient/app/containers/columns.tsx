import {ColumnDef} from "@tanstack/react-table";

export interface Container {
    id: string;
    names: string[];
    images: string;
    command: string;
    created: string;
    state: string;
}

export const columns: ColumnDef<Container>[] = [
    {
        header: 'Id',
        accessorKey: "id"
    },
    {
        header: 'Names',
        accessorKey: "names",
    },
    {
        header: 'Image',
        accessorKey: "image"
    },
    {
        header: 'Command',
        accessorKey: "command"
    },
    {
        header: 'Created',
        accessorKey: "created"
    },
    {
        header: 'State',
        accessorKey: "state"
    },
];
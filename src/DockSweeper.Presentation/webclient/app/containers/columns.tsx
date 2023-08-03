import {ColumnDef} from "@tanstack/react-table";
import React from "react";
import {Button} from "@/components/ui/button";
import { ArrowUpDown } from "lucide-react";
import {match} from "ts-pattern";
import Link from "next/link";

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
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Id
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },
        accessorKey: "id"
    },
    {
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Names
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },
        accessorKey: "names",
        cell: ({ row }) => (
            <div>
                {row.original.names.map((name, index) => (
                    <div key={name}>
                        <Link href={`/docker/containers/${row.original.id}`} className="underline">
                            {name.substring(1)}
                        </Link>
                    </div>
                ))}
            </div>
        ),
        filterFn: (row, id, filterValue) => {
            return row.original.names.some(name => name.includes(filterValue))
        }
    },
    {
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Image
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },
        accessorKey: "image"
    },
    {
        header: 'Command',
        accessorKey: "command"
    },
    {
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    Created
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },
        accessorKey: "created"
    },
    {
        header: ({ column }) => {
            return (
                <Button
                    variant="ghost"
                    onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
                >
                    State
                    <ArrowUpDown className="ml-2 h-4 w-4" />
                </Button>
            )
        },
        accessorKey: "state",
        cell: ({ row }) => {
            const state = row.original.state;
            const color = match<string, string>(state)
                .with("running", () => "bg-green-200 text-green-700")
                .with("exited", () => "bg-red-200 text-red-700")
                .with("created", () => "bg-yellow-200 text-yellow-700")
                .otherwise(() => "bg-gray-200 text-gray-700");

            return <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${color}`}>{state}</span>
        }
    },
];
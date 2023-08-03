"use client";

import {
    ColumnDef, ColumnFiltersState,
    flexRender,
    getCoreRowModel, getFilteredRowModel,
    getPaginationRowModel, getSortedRowModel,
    SortingState,
    useReactTable,
} from "@tanstack/react-table"

import {Table, TableBody, TableCell, TableHead, TableHeader, TableRow,} from "@/components/ui/table"
import { Button } from "@/components/ui/button";
import {useEffect, useState} from "react";
import {Input} from "@/components/ui/input";
import {Switch} from "@/components/ui/switch";
import {Label} from "@/components/ui/label";
import {match} from "ts-pattern";

interface DataTableProps<TData, TValue> {
    columns: ColumnDef<TData, TValue>[]
    data: TData[]
}

export function DataTable<TData, TValue>({
                                             columns,
                                             data,
                                         }: DataTableProps<TData, TValue>) {
    
    const [sorting, setSorting] = useState<SortingState>([]);
    const [columnFilters, setColumnFilters] = useState<ColumnFiltersState>(
        []
    )
    const [showActive, setShowActive] = useState(false);
    useEffect(() => {
        const filter = match(showActive)
            .with(true, () => [])
            .with(false, () => [
                {
                    id: "state",
                    value: "running",
                },
            ])
            .exhaustive();

        setColumnFilters(filter);
    }, [showActive]);


    const table = useReactTable({
        data,
        columns,
        getCoreRowModel: getCoreRowModel(),
        getPaginationRowModel: getPaginationRowModel(),
        onSortingChange: setSorting,
        getSortedRowModel: getSortedRowModel(),
        onColumnFiltersChange: setColumnFilters,
        getFilteredRowModel: getFilteredRowModel(),
        state:{
            sorting,
            columnFilters,
        },
    });

    return <div>
        <div className="flex w-full justify-between">
            <div className="flex items-center py-4">
                <Input
                    placeholder="Filter by name..."
                    value={(table.getColumn("names")?.getFilterValue() as string) || ""}
                    onChange={(event) => table.getColumn("names")?.setFilterValue(event.target.value)}
                    className="max-w-sm"
                />
            </div>

            <div className="flex items-center space-x-2">
                <Switch id="showActive" onCheckedChange={setShowActive} checked={showActive}/>
                <Label htmlFor="showActive-mode">Show non-active containers</Label>
            </div>
        </div>
        <div className="rounded-md border">
            <Table>
                <TableHeader>
                    {table.getHeaderGroups().map(headerGroup => <TableRow key={headerGroup.id}>
                        {headerGroup.headers.map(header =>
                            <TableHead key={header.id}>
                                {header.isPlaceholder
                                    ? null
                                    : flexRender(
                                        header.column.columnDef.header,
                                        header.getContext()
                                    )}
                            </TableHead>)}
                    </TableRow>)}
                </TableHeader>
                <TableBody>
                    {table.getRowModel().rows?.length ? table.getRowModel().rows.map((row) => <TableRow
                        key={row.id}
                        data-state={row.getIsSelected() && "selected"}
                    >
                        {row.getVisibleCells().map((cell) => (
                            <TableCell key={cell.id}>
                                {flexRender(cell.column.columnDef.cell, cell.getContext())}
                            </TableCell>
                        ))}
                    </TableRow>) : <TableRow>
                        <TableCell colSpan={columns.length} className="h-24 text-center">
                            No results.
                        </TableCell>
                    </TableRow>}
                </TableBody>
            </Table>
        </div>
        <div className="flex items-center justify-end space-x-2 py-4">
            <Button
                variant="outline"
                size="sm"
                onClick={() => table.previousPage()}
                disabled={!table.getCanPreviousPage()}
            >
                Previous
            </Button>
            <Button
                variant="outline"
                size="sm"
                onClick={() => table.nextPage()}
                disabled={!table.getCanNextPage()}
            >
                Next
            </Button>
        </div>
    </div>
}

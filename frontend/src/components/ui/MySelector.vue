<script setup lang="ts">
import type { IFilterItem } from '@/types/filter';

const props = defineProps<{
    items: IFilterItem[]
    modelValue: number | null
    label: string
}>();

const emit = defineEmits<{
  (e: 'update:modelValue', value: number | null): void;
}>();

function onChange(event: Event) {
  const rawValue = (event.target as HTMLSelectElement).value;
  emit('update:modelValue', rawValue === "" ? null : +rawValue);
}
</script>

<template>
    <select
      :value="modelValue"
      @change="onChange"
      class="w-full font-russo rounded text-white p-3 bg-secondary shadow-md transition duration-150 focus:outline-none focus:brightness-110"
    >
        <option value="" class="bg-background text-white">{{ label }}</option>
        <option
            v-for="item in items"
            :key="item.Id"
            :value="item.Id"
            class="bg-background text-white"
        >
            {{ item.Name }}
        </option>
    </select>
</template>
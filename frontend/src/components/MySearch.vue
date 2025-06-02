<script setup lang="ts">
import MySelector from '@/components/ui/MySelector.vue';
import type { IFilterItem } from '@/types/filter';
import { computed } from 'vue';

const props = withDefaults(defineProps<{
  modelValue: string,
  placeholder: string,
  fontSize?: string,
  selectedGenreId: number | null,
  selectedPlatformId: number | null,
  selectedDeveloperId: number | null,
  selectedPublisherId: number | null,
  genres: IFilterItem[],
  platforms: IFilterItem[],
  developers: IFilterItem[],
  publishers: IFilterItem[],
}>(), {
  fontSize: 'text-xl',
});

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
  (e: 'update:selectedGenreId', value: number | null): void
  (e: 'update:selectedPlatformId', value: number | null): void
  (e: 'update:selectedDeveloperId', value: number | null): void
  (e: 'update:selectedPublisherId', value: number | null): void
  (e: 'submit'): void
}>();

const localGenreId = computed({
  get: () => props.selectedGenreId,
  set: (value) => emit('update:selectedGenreId', value)
});

const localPlatformId = computed({
  get: () => props.selectedPlatformId,
  set: (value) => emit('update:selectedPlatformId', value)
});

const localDeveloperId = computed({
  get: () => props.selectedDeveloperId,
  set: (value) => emit('update:selectedDeveloperId', value)
});

const localPublisherId = computed({
  get: () => props.selectedPublisherId,
  set: (value) => emit('update:selectedPublisherId', value)
});

const handleSubmit = (e: Event) => {
  e.preventDefault()
  emit('submit')
}

</script>

<template>
    <div class="px-5 pt-5">
        <form @submit="handleSubmit" class="w-full flex flex-col gap-2">
          <MyInput
            :modelValue="modelValue"
            :fontSize="fontSize"
            @update:modelValue="(value: string) => emit('update:modelValue', value)"
            @keydown.enter="emit('submit')"
            background-color="bg-secondary"
            :placeholder="placeholder"
            class="w-full"/>
          <div class="flex flex-row justify-between gap-2">
            <MySelector class="flex-1" v-model="localGenreId" :items="genres" label="Жанр"/>
            <MySelector class="flex-1" v-model="localDeveloperId" :items="developers" label="Разработчик"/>
            <MySelector class="flex-1" v-model="localPublisherId" :items="publishers" label="Издатель"/>
            <MySelector class="flex-1" v-model="localPlatformId" :items="platforms" label="Платформа"/>
          </div>
        </form>
    </div>
</template>
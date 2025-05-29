<script setup lang="ts">
interface CardProps {
  imageSrc: string,
  aspect?: string
}

const props = withDefaults(defineProps<CardProps>(), {
  aspect: 'aspect-[2/3]',
})
</script>

<template>
  <div :class="['w-full overflow-hidden rounded shadow-md', props.aspect]">
    <img
      :src="props.imageSrc"
      alt="Image"
      class="w-full h-full object-cover object-center"
    />
  </div>
</template>